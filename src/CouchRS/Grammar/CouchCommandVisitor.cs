using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Irony.Parsing;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar.KeyOutputTransformation;

namespace CouchRS.Grammar
{
    /// <summary>
    /// Traverses the ParseTree produced when the text command is parsed as CouchQuery syntax,
    /// and builds up the request(s) that will be issued to the CouchDB server.  Notice the similar
    /// approach to the JsonVisitor class - that's because Alex is a genius and Jim likes to copy him. :-)
    /// </summary>
    public class CouchCommandVisitor
    {
         #region Static Members

        static Parser _parser;

        static CouchCommandVisitor()
        {
            _parser = new Parser(new Grammar.CouchGrammar());
        } 

        #endregion

        public Dictionary<string, Func<ParseTreeNode, List<CouchRequestContainer>, List<CouchRequestContainer>>> NodeActions;
        public List<CouchRequestContainer> Requests { get; set; }

        private CouchDbCommand _cmd;
        private Dictionary<string, Action<List<CouchRequestContainer>, object>> _queryOptionProcessor;

        public CouchCommandVisitor()
        {
            NodeActions = new Dictionary<string, Func<ParseTreeNode, List<CouchRequestContainer>, List<CouchRequestContainer>>>()
                              {
                                  {"query", ParseQuery},
                                  {"stmt", ParseStatement},
                                  {"documentStatement", ParseDocument},
                                  {"view", ParseView},
                                  {"queryOptionList", ParseQueryOptionList},
                                  {"keyArray", ParseArrayKey},
                                  {"keyObject", ParseObjectKey},
                                  {"keyValue", ParseKeyValue},
                                  {"binExpr", ParseBinaryExpression},
                                  {"where", ParseWhereExpression}
                              };
            _queryOptionProcessor = new Dictionary<string, Action<List<CouchRequestContainer>, object>>()
                                        {
                                            {"group", (requests, value) => { requests.ForEach(a => a.Uri.Group()); }},
                                            {"group_level", (requests, value) => { requests.ForEach(a => a.Uri.Group((int)value)); }},
                                            {"limit", (requests, value) => { requests.ForEach(a => a.Uri.Limit((int)value)); }},
                                            {"skip", (requests, value) => { requests.ForEach(a => a.Uri.Skip((int)value)); }},
                                            {"reduce", (requests, value) => { if(!Convert.ToBoolean(value)) requests.ForEach(a => a.Uri.NoReduce()); }},
                                            {"allow_stale", (requests, value) => { if(Convert.ToBoolean(value)) requests.ForEach(a => a.Uri.StaleOk()); }},
                                            {"descending", (requests, value) => { if(Convert.ToBoolean(value)) requests.ForEach(a => a.Uri.Descending()); }},
                                            {"include_docs", (requests, value) => { if(Convert.ToBoolean(value)) requests.ForEach(a => a.Uri.IncludeDocuments()); }},
                                            {"inclusive_end", (requests, value) => { if(!Convert.ToBoolean(value)) requests.ForEach(a => a.Uri.NonInclusiveRange()); }}
                                        };
        }

        public void Visit(CouchDbCommand command)
        {
            _cmd = command;
            var parsedCommand = _parser.Parse(_cmd.CommandText);
            if (parsedCommand.HasErrors())
                throw new Exception(
                    String.Join("\n",
                    parsedCommand.ParserMessages
                    .Select(m => String.Format("{0} at line {1}", m.Message, m.Location.Line))
                    .ToArray())
                );
            Requests = Process(parsedCommand.Root, new List<CouchRequestContainer>());
            Requests.ForEach(a => a.ApplyWhereClauseToKeys());
        }

        private List<CouchRequestContainer> Process(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            if(NodeActions.ContainsKey(node.Term.Name))
            {
                return NodeActions[node.Term.Name](node, requests);
            }
            else
            {
                return node.ChildNodes.Aggregate(requests, (current, child) => Process(child, current));
            }
        }

        private List<CouchRequestContainer> ParseQuery(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            return node.ChildNodes.SelectMany(child => Process(child, requests)).ToList();
        }

        private List<CouchRequestContainer> ParseStatement(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            var uri = _cmd.Connection.BuildCouchUri();
            var reqList = new List<CouchRequestContainer>() {new CouchRequestContainer() {Uri = uri}};
            return node.ChildNodes.Aggregate(reqList, (current, child) => Process(child, current));
        }

        private List<CouchRequestContainer> ParseView(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            requests.ForEach(a =>
            {
                a.Uri.Design(node.ChildNodes[1].Token.Text);
                a.Uri.View(node.ChildNodes[2].Token.Text);
            });
            return requests;
        }

        private List<CouchRequestContainer> ParseDocument(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            var docId = node.LastChild.Term.Name == "param" ? GetParamValue(node.LastChild) : node.LastChild.Token.Value;
            requests.ForEach(a => a.Uri.Id(docId));
            return requests;
        }

        private List<CouchRequestContainer> ParseQueryOptionList(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            foreach(var qryOption in node.ChildNodes.Where(x => x.Term.Name == "queryOption"))
            {
                _queryOptionProcessor[qryOption.ChildNodes[0].Token.Text.ToLower()](requests, qryOption.ChildNodes[2].Token.Value);
            }
            return requests;
        }

        private List<CouchRequestContainer> ParseArrayKey(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            requests.ForEach(a => a.Transformer = new ArrayKeyTransformer());
            return ParseCompositeKey(node, requests);
        }

        private List<CouchRequestContainer> ParseObjectKey(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            requests.ForEach(a => a.Transformer = new ObjectKeyTransformer());
            return ParseCompositeKey(node, requests);
        }

        private List<CouchRequestContainer> ParseCompositeKey(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            var keyOrder = node.ChildNodes.First(x => x.Term.Name == "keys").ChildNodes.Select(k => k.Token.Text).ToList();
            requests.ForEach(a =>
                                 {
                                     a.StartKeys = keyOrder.ToDictionary(k => k, v => (object)null);
                                     a.EndKeys = keyOrder.ToDictionary(k => k, v => (object)null);
                                 });
            return requests;
        }

        private List<CouchRequestContainer> ParseKeyValue(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            requests.ForEach(a =>
            {
                a.Transformer = new ValueKeyTransformer();
                a.StartKeys.Add(node.LastChild.Token.Text, null);
                a.EndKeys.Add(node.LastChild.Token.Text, null);
            });
            return requests;
        }

        private List<CouchRequestContainer> ParseBinaryExpression(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            switch(node.ChildNodes[1].Term.Name.ToLower())
            {
                case "and":
                    ParseBinaryExpression(node.FirstChild, requests);
                    ParseBinaryExpression(node.LastChild, requests);
                    break;
                case "or":
                    var copyList = GetRequestListCopy(requests);
                    ParseBinaryExpression(node.FirstChild, requests);
                    ParseBinaryExpression(node.LastChild, copyList);
                    requests.AddRange(copyList);
                    break;
                default:
                    ParseKeyComparisonExpression(node, requests);
                    break;
            }
            return requests;
        }

        private List<CouchRequestContainer> ParseWhereExpression(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            requests.ForEach(a => a.HasWhere = true);
            return node.ChildNodes.Aggregate(requests, (current, child) => Process(child, current));
        }

        private void ParseKeyComparisonExpression(ParseTreeNode node, List<CouchRequestContainer> requests)
        {
            var keyName = node.FirstChild.Token.Text;
            if (!requests.SelectMany(s => s.StartKeys.Keys).Contains(keyName))
                throw new Exception(String.Format("'{0}' from where clause not specified in the key declaration", keyName));

            if (node.ChildNodes[1].Term.Name.ToLower() == "between")
                requests.ForEach(a =>
                                     {
                                         a.IsRange = true;
                                         a.StartKeys[keyName] = node.ChildNodes[2].FirstChild.Term.Name == "param" ?
                                                                    GetParamValue(node.ChildNodes[2].FirstChild) :
                                                                    node.ChildNodes[2].FirstChild.Token.Value;
                                         a.EndKeys[keyName] = node.ChildNodes[2].LastChild.Term.Name == "param" ?
                                                                    GetParamValue(node.ChildNodes[2].LastChild) :
                                                                    node.ChildNodes[2].LastChild.Token.Value;
                                     });   
            else
                requests.ForEach(a => a.StartKeys[keyName] = a.EndKeys[keyName] = node.ChildNodes[2].Term.Name == "param" ?
                                                                                        GetParamValue(node.ChildNodes[2]) :
                                                                                        node.ChildNodes[2].Token.Value);
        }

        private object GetParamValue(ParseTreeNode node)
        {
            var obj = _cmd.Parameters
                .Cast<CouchDataParameter>()
                .First(p => p.ParameterName == node.Token.Text).Value;

            var sObj = obj as string;
            if (sObj != null)
            {
                decimal intVal = 0;
                if (Decimal.TryParse(sObj, out intVal))
                    obj = intVal;
            }
            return obj;
        }

        private static List<CouchRequestContainer> GetRequestListCopy(List<CouchRequestContainer> requests)
        {
            using (var ms = new MemoryStream())
            {
                // TODO: look into other binary serialization options that are faster than what's in the BCL...
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, requests);
                ms.Position = 0;

                return formatter.Deserialize(ms) as List<CouchRequestContainer>;
            }
        }
    }
}

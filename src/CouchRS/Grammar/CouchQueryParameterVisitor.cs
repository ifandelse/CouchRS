using System;
using System.Collections.Generic;
using System.Linq;
using Irony.Parsing;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Grammar
{
    /// <summary>
    /// Visits a CouchQuery command text and produces a collection
    /// of CouchQueryParameters used in the command.
    /// </summary>
    public class CouchQueryParameterVisitor
    {
        #region Static Members

        static Parser _parser;

        static CouchQueryParameterVisitor()
        {
            _parser = new Parser(new CouchGrammar());
        }

        #endregion

        public CouchQueryParameterVisitor()
        {
            Parameters = new CouchDataParameterCollection();
        }

        public CouchDataParameterCollection Parameters { get; set; }

        public void Visit(CouchDbCommand command)
        {
            var expr = _parser.Parse(command.CommandText);
            if (expr.HasErrors())
                throw new Exception(
                    String.Join("\n",
                    expr.ParserMessages
                    .Select(m => String.Format("{0} at line {1}", m.Message, m.Location.Line))
                    .ToArray())
                );
            GetParamNames(expr.Root)
                .ForEach(a => Parameters
                    .Add(new CouchDataParameter()
                    {
                        ParameterName = a
                    }));
        }

        private List<string> GetParamNames(ParseTreeNode parseTreeNode)
        {
            var paramNames = new List<String>();
            if (parseTreeNode.Term.Name == "param")
            {
                paramNames.Add(parseTreeNode.Token.Text);
            }

            if (parseTreeNode.ChildNodes.Count() > 0)
            {
                foreach (var child in parseTreeNode.ChildNodes)
                {
                    paramNames.AddRange(GetParamNames(child));
                }
            }
            return paramNames;
        }
    }
}
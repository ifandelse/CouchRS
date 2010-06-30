using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Symbiote.Core;
using Symbiote.Core.Extensions;

namespace CouchRS.Json
{
    public class JsonVisitor
    {
        static Regex _jstart = new Regex(@"^\s*(?<char>.)", RegexOptions.Compiled);
        protected List<Dictionary<string, string>> _normalizedRecords;
        public Dictionary<Type, Func<JToken, string, List<List<Tuple<string, string>>>, List<List<Tuple<string, string>>>>> typeProcessor;
        
        public HashSet<string> FieldSet { get; set; }
        public List<List<Tuple<string,string>>> Records { get; set; }
        public List<Dictionary<string, string>> NormalizedRecords
        {
            get
            {
                if (_normalizedRecords == null)
                    BuildNormalizedRecords();
                return _normalizedRecords;
            }
        }

        protected void BuildNormalizedRecords()
        {
            _normalizedRecords = new List<Dictionary<string, string>>(Records.Count);
            Records.ForEach(r =>
                                {
                                    var list = FieldSet.ToList();
                                    var set = new Dictionary<string, string>(list.Count);
                                    r.ForEach(t =>
                                                  {
                                                      set.Add(t.Value1, t.Value2);
                                                      list.Remove(t.Value1);
                                                  });
                                    list.ForEach(c => set.Add(c, null));
                                    _normalizedRecords.Add(set);
                                });
        }

        public JsonVisitor()
        {
            typeProcessor = new Dictionary<Type, Func<JToken, string, List<List<Tuple<string, string>>>, List<List<Tuple<string, string>>>>> {
                    {typeof(JObject),ProcessObject},
                    {typeof(JProperty),ProcessProperty},
                    {typeof(JArray),ProcessArray},
                    {typeof(JValue),ProcessValue}
                };

            Records = new List<List<Tuple<string, string>>>();
            Records.Add(new List<Tuple<string, string>>());
            FieldSet = new HashSet<string>();
        }

        protected List<List<Tuple<string, string>>> Process(JToken jObject, string prefix, List<List<Tuple<string,string>>> records)
        {
            return typeProcessor[jObject.GetType()](jObject, prefix, records);
        }

        public void Traverse(string json)
        {
            BeforeVisit();
            JToken obj;
            var match = _jstart.Match(json);
            if (match.Groups["char"].Value == "{")
            {
                obj = JObject.Parse(json);
            }
            else
            {
                obj = JArray.Parse(json);
            }
            Records = Process(obj, "", Records);
        }

        private void BeforeVisit()
        {
            _normalizedRecords = null;
            FieldSet.Clear();
            Records.Clear();
            Records.Add(new List<Tuple<string, string>>());

        }

        protected List<List<Tuple<string, string>>> ProcessValue(JToken token, string prefix, List<List<Tuple<string, string>>> records)
        {
            var jValue = token as JValue;
            FieldSet.Add(prefix);
            var val = Tuple.Create(prefix, jValue.Value == null ? null : jValue.Value.ToString());
            records.ForEach(x => x.Add(val));
            return records;
        }

        protected List<List<Tuple<string, string>>> ProcessArray(JToken token, string prefix, List<List<Tuple<string, string>>> records)
        {
            // We don't want the key being treated like a member array and thus blowing out the cartesian product
            if (prefix == "key")
            {
                var keyidx = 0;
                return token
                        .Children()
                        .Select(keyMember => new JProperty(String.Format("key{0}", keyidx++), keyMember.Value<string>()))
                        .Aggregate(records, (current, tkn) => ProcessProperty(tkn, "", current));
            }

            if (!token.HasValues)
                return records;

            return token
                .Children()
                .Select(x =>
                             {
                                 var copy = DuplicateList(records);
                                 return Process(x, prefix, copy);
                             })
                .SelectMany(x => x.ToList()).ToList();
        }

        protected List<List<Tuple<string, string>>> ProcessProperty(JToken token, string prefix, List<List<Tuple<string, string>>> records)
        {
            var property = token as JProperty;
            var name = string.IsNullOrEmpty(prefix) ? property.Name : String.Format("{0}.{1}",prefix,property.Name);
            return Process(property.Value, name, records);
        }

        protected List<List<Tuple<string, string>>> ProcessObject(JToken token, string prefix, List<List<Tuple<string, string>>> records)
        {
            if (token.HasValues)
                    token
                    .Children()
                    .ForEach(x => records = Process(x, prefix, records));
            
            return records;
        }
        
        protected List<List<Tuple<string, string>>> DuplicateList(List<List<Tuple<string, string>>> list)
        {
            return
                list
                .Select(x =>
                {
                    var copy = new List<Tuple<string, string>>(FieldSet.Count);
                    x.ForEach(copy.Add);
                    return copy;
                }).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CouchRS.Grammar.KeyOutputTransformation
{
    [Serializable]
    public class ValueKeyTransformer:IKeyTransformer
    {
        public object Transform(Dictionary<string, object> search)
        {
            return search.First().Value;
        }
    }
}
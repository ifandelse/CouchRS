using System;
using System.Collections.Generic;
using System.Linq;

namespace CouchRS.Grammar.KeyOutputTransformation
{
    [Serializable]
    public class ArrayKeyTransformer : IKeyTransformer
    {
        public object Transform(Dictionary<string, object> search)
        {
            return search.Select(v => v.Value).ToArray();
        }
    }
}
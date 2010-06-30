using System;
using System.Collections.Generic;

namespace CouchRS.Grammar.KeyOutputTransformation
{
    [Serializable]
    public class ObjectKeyTransformer : IKeyTransformer
    {
        public object Transform(Dictionary<string, object> search)
        {
            return search;
        }
    }
}
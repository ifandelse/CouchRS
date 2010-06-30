using System.Collections.Generic;

namespace CouchRS.Grammar.KeyOutputTransformation
{
    public interface IKeyTransformer
    {
        object Transform(Dictionary<string, object> search);
    }
}
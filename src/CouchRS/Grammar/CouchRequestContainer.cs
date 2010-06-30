using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar.KeyOutputTransformation;

namespace CouchRS.Grammar
{
    /// <summary>
    /// This is a container/metadata class that holds information about a single request
    /// that needs to be made against a CouchDB.  Since UNIONs or parenthetical logic
    /// can results in multiple requests, it's possible for one query to generate several
    /// CouchRequestContainer objects.
    /// </summary>
    [Serializable]
    public class CouchRequestContainer : ISerializable
    {
        public CouchRequestContainer()
        {
            StartKeys = new Dictionary<string, object>();
            EndKeys = new Dictionary<string, object>();
        }

        // This constructor overload exists strictly for deserializing the couch request container
        // when one is deep-copied when a WHERE clause hits an OR keyword, thus branching the query
        // into multiple requests.
        protected CouchRequestContainer(SerializationInfo info, StreamingContext context)
        {
            Transformer = info.GetValue("Transformer", typeof (IKeyTransformer)) as IKeyTransformer;
            var tmpUri = new Uri(info.GetString("CouchUri"));
            var localPath = tmpUri.LocalPath.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
            var database = localPath[0];
            var designDoc = localPath[2];
            var view = localPath[4];
            Uri = new CouchUri(tmpUri.Scheme, tmpUri.Host, tmpUri.Port, database);
            Uri.Design(designDoc);
            Uri.View(view);
            StartKeys = info.GetValue("StartKeys", typeof (Dictionary<string, object>)) as Dictionary<string, object>;
            EndKeys = info.GetValue("EndKeys", typeof(Dictionary<string, object>)) as Dictionary<string, object>;
            IsRange = info.GetBoolean("IsRange");
            HasWhere = info.GetBoolean("HasWhere");
        }

        public IKeyTransformer Transformer;
        public CouchUri Uri { get; set;}
        public Dictionary<string,object> StartKeys { get; set;}
        public Dictionary<string,object> EndKeys { get; set;}
        public bool IsRange { get; set;}
        public bool HasWhere { get; set; }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Transformer", Transformer);
            info.AddValue("CouchUri", Uri.ToString());
            info.AddValue("StartKeys", StartKeys);
            info.AddValue("EndKeys", EndKeys);
            info.AddValue("IsRange", IsRange);
            info.AddValue("HasWhere", HasWhere);
        }

        #endregion

        public void ApplyWhereClauseToKeys()
        {
            if(HasWhere)
            {
                if (IsRange)
                    Uri.ByRange(Transformer.Transform(StartKeys), Transformer.Transform(EndKeys));
                else
                    Uri.Key(Transformer.Transform(StartKeys));
            }
        }
    }
}
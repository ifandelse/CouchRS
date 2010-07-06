using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Symbiote.Core.Extensions;

namespace CouchRS.DataProcessingExtension
{
    /// <summary>
    /// Helper class that builds up a proper request for a CouchDB.
    /// This class is nearly the same public API from Alex Robson's CouchUri class in his "Relax" Couch API -
    /// the main difference being that a UriBuilder is used internally instead of a StringBuilder.
    /// I HIGHLY recommend that you check out Relax if you're looking for a powerful and intuitive way to leverage
    /// CouchDB in .NET applications!
    /// </summary>
    [Serializable]
    public class CouchUri : ICloneable
    {
        UriBuilder _builder = new UriBuilder();
        Dictionary<string, string> _queryParams = new Dictionary<string, string>();

        public string DatabaseName { get; set; }

        public static CouchUri Build(string prefix, string server, int port, string database)
        {
            return new CouchUri(prefix, server, port, database);
        }

        public static CouchUri Build(string prefix, string user, string password, string server, int port, string database)
        {
            return new CouchUri(user, password, prefix, server, port, database);
        }

        public static CouchUri Build(string prefix, string server, int port)
        {
            return new CouchUri(prefix, server, port);
        }

        public static CouchUri Build(string prefix, string user, string password, string server, int port)
        {
            return new CouchUri(user, password, prefix, server, port);
        }

        public CouchUri Attachment(string attachmentName)
        {
            _builder.Path += "/" + attachmentName;
            return this;
        }

        public CouchUri BulkInsert()
        {
            _builder.Path += "/_bulk_docs";
            return this;
        }

        public CouchUri ByRange<TKey>(TKey start, TKey end)
        {
            return
                this
                .StartKey(start)
                .EndKey(end);
        }

        public CouchUri Changes(Feed feed, int since)
        {
            _builder.Path += "/_changes";

            if (feed != Feed.Simple)
            {
                _queryParams["feed"] = feed == Feed.Continuous
                                          ? "continuous"
                                          : "longpoll";
            }
            _queryParams["since"] = since.ToString();
            return this;
        }

        public CouchUri CleanupViews()
        {
            _builder.Path += "/_view_cleanup";
            return this;
        }

        public CouchUri Compact()
        {
            _builder.Path += "/_compact";
            return this;
        }

        public CouchUri CompactView(string designDocument)
        {
            _builder.Path += "/_compact/{0}".AsFormat(designDocument);
            return this;
        }

        public CouchUri Descending()
        {
            _queryParams["descending"] = "true";
            return this;
        }

        public CouchUri Design(string designDocumentName)
        {
            _builder.Path += "/_design/" + designDocumentName;
            return this;
        }

        public CouchUri Format(string format)
        {
            _queryParams["format"] = format;
            return this;
        }

        public CouchUri IncludeDocuments()
        {
            _queryParams["include_docs"] = "true";
            return this;
        }

        public CouchUri NonInclusiveRange()
        {
            _queryParams["inclusive_end"] = "false";
            return this;
        }

        public CouchUri Id<TKey>(TKey key)
        {
            _builder.Path += "/" + key.ToString().Trim('"');
            return this;
        }

        public CouchUri IdAndRev<TKey, TRev>(TKey key, TRev rev)
        {
            return
                this
                .Id(key)
                .Revision(rev);
        }

        public CouchUri Key<TKey>(TKey key)
        {
            var json = key.ToJson(false);
            _queryParams["key"] = json;
            return this;
        }

        public CouchUri KeyAndRev<TKey, TRev>(TKey key, TRev rev)
        {
            return
                this
                .Key(key)
                .Revision(rev);
        }

        public CouchUri Group()
        {
            _queryParams["group"] = "true";
            return this;
        }

        public CouchUri Group(int groupLevel)
        {
            _queryParams["group"] = "true";
            _queryParams["group_level"] = groupLevel.ToString();
            return this;
        }

        public CouchUri Limit(int limit)
        {
            _queryParams["limit"] = limit.ToString();
            return this;
        }

        public CouchUri List(string listName)
        {
            _builder.Path += "/_list/" + listName;
            return this;
        }

        public CouchUri ListAll()
        {
            _builder.Path += "/_all_docs";
            return this;
        }

        public CouchUri NoReduce()
        {
            _queryParams["reduce"] = "false";
            return this;
        }

        public CouchUri Replicate()
        {
            _builder.Path += "/_replicate";
            return this;
        }

        public CouchUri Revision<TRev>(TRev revision)
        {
            _queryParams["rev"] = revision.ToString().Trim('"');
            return this;
        }

        public CouchUri StartKey<TKey>(TKey start)
        {
            var startKey = start.ToJson(false);
            _queryParams["startkey"] = startKey;
            return this;
        }

        public CouchUri EndKey<TKey>(TKey end)
        {
            var endKey = end.ToJson(false);
            _queryParams["endkey"] = endKey;
            return this;
        }

        public CouchUri Skip(int number)
        {
            _queryParams["skip"] = number.ToString();
            return this;
        }

        public CouchUri StaleOk()
        {
            _queryParams["stale"] = "ok";
            return this;
        }

        public CouchUri View(string viewName)
        {
            _builder.Path += "/_view/" + viewName;
            return this;
        }

        public CouchUri(string prefix, string server, int port, string database)
            : this(prefix, null, null, server, port, database) { }

        public CouchUri(string prefix, string server, int port)
            : this(prefix, null, null, server, port, null) { }

        public CouchUri(string prefix, string user, string password, string server, int port)
            : this(prefix, user, password, server, port, null) { }

        public CouchUri(string prefix, string user, string password, string server, int port, string database)
        {
            _builder.UserName = user;
            _builder.Password = password;
            _builder.Scheme = prefix;
            _builder.Host = server;
            _builder.Port = port;
            _builder.Path = database;
            DatabaseName = database;
        }

        protected CouchUri(string content)
        {
            _builder = new UriBuilder(content);
            var collection = HttpUtility.ParseQueryString(_builder.Query);
            _queryParams = collection.AllKeys.ToDictionary(k => k, collection.Get);
        }

        public object Clone()
        {
            return new CouchUri(ToString());
        }

        public override string ToString()
        {
            var pairs =
                _queryParams
                .Select(pair => pair.Key + "=" + pair.Value)
                .ToArray();
            _builder.Query = String.Join("&", pairs);

            return _builder.ToString();
        }
    }
}

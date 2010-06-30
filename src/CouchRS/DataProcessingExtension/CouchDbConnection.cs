using System;
using System.Net;
using Microsoft.ReportingServices.DataProcessing;

namespace CouchRS.DataProcessingExtension
{
    /// <summary>
    /// Represents the SSRS Connection to a CouchDB server.
    /// </summary>
    public class CouchDbConnection : IDbConnectionExtension
    {
        private int _connectionTimeout = -1;
        private string _connectionString = "";
        private Uri _uri;
        private bool _connectionOpened;

        public CouchDbConnection()
        {

        }

        public CouchDbConnection(string connectionString) 
        {
            ConnectionString = connectionString;
            _uri = new Uri(connectionString);
        }

        public virtual CouchUri BuildCouchUri()
        {
            return new CouchUri(_uri.Scheme,_uri.Host, _uri.Port, _uri.AbsolutePath.TrimStart('/'));
        }

        #region IDbConnection Members

        public IDbTransaction BeginTransaction()
        {
            return new CouchDbTransaction();
        }

        public void Close()
        {
            //  There's nothing to do here except note that the connetion isn't open!
            _connectionOpened = false;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                _connectionString = value;
                _uri = new Uri(value);
            }
        }

        public int ConnectionTimeout { get { return _connectionTimeout; } }

        public IDbCommand CreateCommand()
        {
            return new CouchDbCommand(this);
        }

        public void Open()
        {
            if (_connectionOpened) return;
            var request = new WebClient();
            var response = request.DownloadString(_uri);
            _connectionOpened = !String.IsNullOrEmpty(response);
        }

        #endregion

        #region IExtension Members

        public string LocalizedName { get { return "Couch Database Connection"; } }

        public void SetConfiguration(string configuration)
        {
            // Nothing to do here...
        }

        #endregion

        #region IDbConnectionExtension Members

        public string Impersonate { set { throw new NotImplementedException("The Couch Data Provider does not support impersonation."); } }
        public bool IntegratedSecurity { get { return false; } set { throw new NotImplementedException("The Couch Data Provider does not support integrated security."); } }
        public string Password { get; set; }
        public string UserName { get; set; }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // You're wondering why we didn't follow the standard Dispose pattern?  Funny you should ask.
            // Dispose() is called after the Query Editor (in SSRS Designer) is opened - but only after it has
            // been opened once before (if memory serves), so it's clear that the developers at MS were
            // using Dispose() to close any existing connection before the user attempts to run the query
            // in the query editor again.  Yeah, we didn't get it either.  
            Close();
        }

        #endregion
    }
}

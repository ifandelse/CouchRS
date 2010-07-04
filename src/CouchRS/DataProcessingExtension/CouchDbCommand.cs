using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.ReportingServices.DataProcessing;
using CouchRS.Grammar;
using CouchRS.Json;

namespace CouchRS.DataProcessingExtension
{
    /// <summary>
    /// Represents a command that will be issue to a CouchDB.
    /// </summary>
    public class CouchDbCommand : IDbCommand, IDbCommandAnalysis
    {
        #region static members

        // When you query in Query Designer and then close out the Data Set dialog, a SECOND
        // call is made to "ExecuteReader()" on the command object, but it's a NEW instance of
        // the command object that no longer has the param values that were originally submitted.
        // This second call to ExecuteReader() is "GetSchemaOnly" behavior, so this static dictionary
        // is to keep track of the most recent value of a param so that a valid query can be made
        // against Couch, and an accurate field list returned to populate the Data Set's field list.
        private static Dictionary<string, object> _lastParamValues = new Dictionary<string, object>();

        #endregion



        private CouchCommandVisitor _visitor;
        private WebClient _webClient;
        private CouchQueryParameterVisitor _paramVisitor;
        private JsonResponseVisitor _jsonResponseVisitor;

        // this constructor overload was provided for better unit testing.  The other constructor is called by the CouchConnetion object.
        public CouchDbCommand(CouchDbConnection connection, WebClient webClient, CouchCommandVisitor visitor, CouchQueryParameterVisitor parameterVisitor, JsonResponseVisitor jsonResponseVisitor)
        {
            Connection = connection;
            Parameters = new CouchDataParameterCollection();
            _webClient = webClient;
            if(!String.IsNullOrEmpty(connection.UserName))
            {
                _webClient.Credentials = new NetworkCredential(connection.UserName, connection.Password);
            }
            _visitor = visitor;
            _paramVisitor = parameterVisitor;
            _jsonResponseVisitor = jsonResponseVisitor;
        }

        public CouchDbCommand(CouchDbConnection connection) 
            : this(connection, new WebClient(), null, new CouchQueryParameterVisitor(), new JsonResponseVisitor())
        {
            _visitor = new CouchCommandVisitor();
        }

        protected CouchDbCommand(IDbCommand command)
            : this(((CouchDbCommand)command).Connection, new WebClient(), null, new CouchQueryParameterVisitor(), new JsonResponseVisitor())
        {
            _visitor = new CouchCommandVisitor();
        }

        public CouchDbConnection Connection { get; protected set; }

        #region IDbCommand Members

        public void Cancel()
        {
            // Nothing to do here....cancel is not supported.
        }

        public IDataParameter CreateParameter()
        {
            return new CouchDataParameter();
        }

        public virtual IDataReader ExecuteReader(CommandBehavior behavior)
        {
            if(behavior == CommandBehavior.SchemaOnly)
            {
                RestoreLastKnownParamValues();
            }
            else
            {
                StoreLastKnownParamValues();
            }
            var responses = new List<string>();
            _visitor.Visit(this);
            _visitor.Requests.ForEach(a => responses.Add(_webClient.DownloadString(a.Uri.ToString())));
            _jsonResponseVisitor.VisitJson(responses);
            return new CouchDataReader(_jsonResponseVisitor.FormattedJson);
        }

        public string CommandText { get; set; }
        public int CommandTimeout { get; set; }
        public CommandType CommandType { get; set; }
        public IDataParameterCollection Parameters { get; set; }
        public IDbTransaction Transaction { get; set; }

        #endregion

        #region IDbCommandAnalysis Members

        public IDataParameterCollection GetParameters()
        {
            _paramVisitor.Visit(this);
            return _paramVisitor.Parameters;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }

            Connection = null;
        }

        #endregion

        private void StoreLastKnownParamValues()
        {
            foreach(var param in Parameters)
            {
                _lastParamValues[((CouchDataParameter) param).ParameterName] = ((CouchDataParameter) param).Value;
            }
        }

        private void RestoreLastKnownParamValues()
        {
            ((CouchDataParameterCollection)Parameters)
                .ForEach(a =>
                            {
                                if(_lastParamValues.ContainsKey(a.ParameterName))
                                {
                                    a.Value = _lastParamValues[a.ParameterName];
                                }
                            });
        }
    }
}
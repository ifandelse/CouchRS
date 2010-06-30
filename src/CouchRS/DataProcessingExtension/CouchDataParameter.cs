using Microsoft.ReportingServices.DataProcessing;

namespace CouchRS.DataProcessingExtension
{
    public class CouchDataParameter : IDataParameter
    {
        public CouchDataParameter() {  }
        public CouchDataParameter(string paramName,object value)
        {
            ParameterName = paramName;
            Value = value;
        }

        #region IDataParameter Members

        public string ParameterName { get; set; }
        public object Value { get; set; }

        #endregion
    }
}
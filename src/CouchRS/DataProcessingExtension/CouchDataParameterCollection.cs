using System.Collections;
using System.Collections.Generic;
using Microsoft.ReportingServices.DataProcessing;

namespace CouchRS.DataProcessingExtension
{
    public class CouchDataParameterCollection : IDataParameterCollection
    {
        private IList<CouchDataParameter> _params;

        public CouchDataParameterCollection()
        {
            Init();
        }

        private void Init()
        {
            _params = new List<CouchDataParameter>();
        }

        public void Clear()
        {
            _params.Clear();
        }

        #region IDataParameterCollection Members

        public int Add(IDataParameter parameter)
        {
            _params.Add((CouchDataParameter)parameter);
            return _params.Count - 1;
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _params.GetEnumerator();
        }

        #endregion
    }
}
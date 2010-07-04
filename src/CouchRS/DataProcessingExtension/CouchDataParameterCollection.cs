using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ReportingServices.DataProcessing;

namespace CouchRS.DataProcessingExtension
{
    public class CouchDataParameterCollection : List<CouchDataParameter>, IDataParameterCollection
    {
        #region IDataParameterCollection Members

        public int Add(IDataParameter parameter)
        {
            if (this.ToList().Where(x => x.ParameterName == parameter.ParameterName).Count() == 0)
            {
                base.Add((CouchDataParameter)parameter);
                return Count - 1;
            }
            else
            {
                return IndexOf(this.ToList().First(x => x.ParameterName == parameter.ParameterName));
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }

        #endregion
    }
}
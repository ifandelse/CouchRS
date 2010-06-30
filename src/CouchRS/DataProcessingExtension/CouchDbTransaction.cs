using Microsoft.ReportingServices.DataProcessing;

namespace CouchRS.DataProcessingExtension
{
    /// <summary>
    /// Transactions for querying are not supported.  This class is basically a NoOp.
    /// </summary>
    public class CouchDbTransaction : IDbTransaction
    {

        #region IDbTransaction Members

        public void Commit()
        {
            // Nothing to do here...
        }

        public void Rollback()
        {
            // Nothing to do here...
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // Nothing to do here...
        }

        #endregion
    }
}
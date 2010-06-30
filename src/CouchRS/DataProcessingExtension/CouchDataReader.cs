using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ReportingServices.DataProcessing;
using CouchRS.Json;

namespace CouchRS.DataProcessingExtension
{
    /// <summary>
    /// IDataReader that takes a JSON response, normalizes it by obtaining the cartesian product
    /// and then produces a relational-style result set that can be traversed by SSRS.
    /// </summary>
    public class CouchDataReader : IDataReader
    {
        private JsonVisitor _visitor;
        IEnumerator<Dictionary<string,string>> _records;
        IList<string> _fields;

        public CouchDataReader(string json)
        {
            _visitor = new JsonVisitor();
            _visitor.Traverse(json);
            _records = _visitor.NormalizedRecords.GetEnumerator();
            _fields = _visitor.FieldSet.ToList();

        }

        #region IDataReader Members

        public int FieldCount
        {
            get { return _fields.Count; }
        }

        public Type GetFieldType(int fieldIndex)
        {
            return typeof (String);
        }

        public string GetName(int fieldIndex)
        {
            return _fields[fieldIndex];
        }

        public int GetOrdinal(string fieldName)
        {
            return _fields.IndexOf(fieldName);
        }

        public object GetValue(int fieldIndex)
        {
            return _records.Current[_fields[fieldIndex]];
        }

        public bool Read()
        {
            if (_records == null)
                return false;
            return _records.MoveNext();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if(_visitor != null)
            {
                _visitor = null;
            }
        }

        #endregion
    }
}
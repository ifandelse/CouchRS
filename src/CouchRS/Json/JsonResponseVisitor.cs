using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CouchRS.Json
{
    public class JsonResponseVisitor
    {
        #region Static Members
        static Regex _jsonStripper = new Regex(@"(?<=""rows"":\[).*(?=\])", RegexOptions.Compiled | RegexOptions.Singleline);
        #endregion

        private StringBuilder _strBuilder = new StringBuilder();

        public string FormattedJson { get { return _strBuilder.ToString(); } }

        public void VisitJson(List<string> jsonResponse)
        {
            _strBuilder = new StringBuilder();
            _strBuilder.AppendLine("[");
            int cnt = 0;
            jsonResponse.ForEach(a =>
                                     {
                                         cnt++;
                                         var match = _jsonStripper.Match(a);
                                         _strBuilder.Append(match.Success ? match.ToString() : a);
                                         if(jsonResponse.Count > 1 && cnt != jsonResponse.Count)
                                         {
                                             _strBuilder.AppendLine(",");
                                         }
                                     });
            _strBuilder.AppendLine().Append("]");
        }
    }
}
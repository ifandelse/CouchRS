using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;
using CouchRS.DataProcessingExtension;
using Machine.Specifications;

namespace CouchRS.Test
{
    public class with_couch_view_query
    {
        protected static string _queryText =
            @"
FROM VIEW(projects,by_is_complete)
WITH KEY[clientId,status,effectiveDate]
WHERE    clientId = 11
AND      status = @Status
AND      effectiveDate BETWEEN(@StartDate, @EndDate)
        
";

        protected static CouchDbCommand cmd;


        Establish context = () =>
                                        {
                                            cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")){CommandText = _queryText};
                                            cmd.Parameters.Add(new CouchDataParameter("Status", null));
                                            cmd.Parameters.Add(new CouchDataParameter("StartDate", new DateTime(2010,5,2)));
                                            cmd.Parameters.Add(new CouchDataParameter("EndDate", new DateTime(2010, 5, 7)));

                                        };

    }
}

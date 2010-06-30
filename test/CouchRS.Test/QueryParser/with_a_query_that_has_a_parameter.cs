using Machine.Specifications;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.QueryParser
{
    public class with_a_query_that_has_a_parameter
    {
        protected static CouchDbCommand cmd;
        

        Establish context = () =>
                            {
                                var query = @"
                        FROM VIEW(projects,view_all)
                        WITH KEY status
                        WHERE status=@Status";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                            };
    }
}
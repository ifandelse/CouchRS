using Machine.Specifications;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar;

namespace CouchRS.Test.QueryParser
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_where_clauses_out_of_order
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                            {
                                var query = @"
                        FROM VIEW(projects,view_all)
                        WITH KEY[status,client_id]
                        WHERE client_id=1 AND status='A'";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                            };

        Because of = () =>
                     {
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_key_properties_in_the_proper_order = () =>
                                                            uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?key=[""A"",1]");

    }
}
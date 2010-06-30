using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_between_clause
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                            {
                                var query = @"
                        FROM VIEW(projects,view_all)
                        WITH KEY some_number
                        WHERE some_number between(1,5)";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                            };

        Because of = () =>
                     {
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_a_start_uri = () =>
                                     uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?startkey=1&endkey=5");

    }
}
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_numeric_literal
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                            {
                                var query = @"
                        FROM VIEW(projects,view_all)
                        WITH KEY foo
                        WHERE foo=42";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };

                            };

        Because of = () =>
                     {
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_a_numeric_valued_key = () =>
                                              uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?key=42");

    }
}
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_array_key
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                            {
                                var query = @"
                                    FROM VIEW(projects,view_all)
                                    WITH KEY [foo,bar]
                                    WHERE foo='bacon'AND bar='sizzle'";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                            };

        Because of = () =>
                     {
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_the_correct_key_format = () =>
                                                uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?key=[""bacon"",""sizzle""]");

    }
}
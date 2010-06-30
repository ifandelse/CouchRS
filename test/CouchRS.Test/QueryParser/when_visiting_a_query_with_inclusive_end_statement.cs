using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_inclusive_end_statement
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                                {
                                    var query = @"
                        FROM VIEW(projects,view_all)
                        USING QUERYOPTIONS(GROUP=true, GROUP_LEVEL=3, DESCENDING=true,INCLUSIVE_END=false)
                        WITH KEY [bacon,sizzle,eggs]
                        WHERE bacon=true AND sizzle=true AND eggs= 'scrambled'";

                                    cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };

                                };

        Because of = () =>
                         {
                             var visitor = new CouchCommandVisitor();
                             visitor.Visit(cmd);
                             uri = visitor.Requests[0].Uri;
                         };

        It should_have_a_correct_uri = () =>
                                       uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?group=true&group_level=3&descending=true&inclusive_end=false&key=[true,true,""scrambled""]");

    }
}
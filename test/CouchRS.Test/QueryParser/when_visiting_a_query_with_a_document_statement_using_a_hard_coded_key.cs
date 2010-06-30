using Machine.Specifications;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar;

namespace CouchRS.Test.QueryParser
{
    public class when_visiting_a_query_with_a_document_statement_using_a_hard_coded_key
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () =>
                                {
                                    var query = @"FROM DOCUMENT('123456789ABC')";

                                    cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                                };

        Because of = () =>
                         {
                             var visitor = new CouchCommandVisitor();
                             visitor.Visit(cmd);
                             uri = visitor.Requests[0].Uri;
                         };

        It should_have_the_proper_url = () => uri.ToString().ShouldEqual(@"http://localhost:5984/test/123456789ABC");
    }
}
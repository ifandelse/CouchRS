using System.Linq;
using Machine.Specifications;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar;

namespace CouchRS.Test.QueryParser
{
    public class when_visiting_a_query_with_a_union_of_a_document_statement_and_a_view_statement
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;
        static CouchCommandVisitor visitor;

        Establish context = () =>
                                {
                                    var query = @"FROM DOCUMENT(@DocumentId) UNION ALL FROM VIEW(myDesignDoc,myView)";

                                    cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                                    cmd.Parameters.Add(new CouchDataParameter("@DocumentId", "123456789ABC"));
                                };

        Because of = () =>
                         {
                             visitor = new CouchCommandVisitor();
                             visitor.Visit(cmd);
                         };

        It should_have_two_urls = () => visitor.Requests.Count.ShouldEqual(2);

        It should_have_the_proper_urls = () => visitor.Requests.Select(x => x.Uri.ToString()).SequenceEqual(new[]
                                                                                                                {
                                                                                                                    "http://localhost:5984/test/123456789ABC",
                                                                                                                    "http://localhost:5984/test/_design/myDesignDoc/_view/myView"
                                                                                                                });
    }
}
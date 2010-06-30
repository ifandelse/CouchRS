using System;
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_mix_of_range_and_parameter_and_literal_where_clauses 
    {
        protected static CouchDbCommand cmd;
        static CouchUri uri;

        Establish context = () => {
                                var query = @"
                                    FROM VIEW(projects,view_all)
                                    WITH KEY{client_id,status, effective_date}
                                    WHERE client_id=1 AND status=@status AND effective_date between(@start,@end)";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                                cmd.Parameters.Add(new CouchDataParameter("@status", "active"));
                                cmd.Parameters.Add(new CouchDataParameter("@start", new DateTime(2010, 5, 2)));
                                cmd.Parameters.Add(new CouchDataParameter("@end", new DateTime(2010, 5, 8)));
                            };

        Because of = () => 
                     {
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_the_correct_uri = () =>
                                         uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?startkey={""client_id"":1,""status"":""active"",""effective_date"":""2010-05-02T00:00:00""}&endkey={""client_id"":1,""status"":""active"",""effective_date"":""2010-05-08T00:00:00""}");
        
    }
}
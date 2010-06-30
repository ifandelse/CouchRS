using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;
using CouchRS.Test.QueryParser;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_string_parameter_containing_a_number : with_a_query_that_has_a_parameter
    {
        static CouchUri uri;

        Because of = () =>
                     {
                         cmd.Parameters.Add(new CouchDataParameter("@Status", "42.75"));
                         var visitor = new CouchCommandVisitor();
                         visitor.Visit(cmd);
                         uri = visitor.Requests[0].Uri;
                     };

        It should_have_converted_the_string_value_to_a_number_type = () =>
                                                                     uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?key=42.75");
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using Newtonsoft.Json.Linq;
using CouchRS.Grammar;
using CouchRS.Test.QueryParser;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_parameter:with_a_query_that_has_a_parameter
    {
        static CouchUri uri;

        Because of = () =>
        {
            cmd.Parameters.Add(new CouchDataParameter("@Status", "foo"));
            var visitor = new CouchCommandVisitor();
            visitor.Visit(cmd);
            uri = visitor.Requests[0].Uri;
        };

        It should_have_the_param_value_substituted_into_uri = () =>
            uri.ToString().ShouldEqual(@"http://localhost:5984/test/_design/projects/_view/view_all?key=""foo""");
    }
}
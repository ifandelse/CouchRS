using System.Linq;
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    public class when_parsing_parameters_from_couch_view_query : with_couch_view_query
    {
        protected static CouchQueryParameterVisitor _visitor;

        Because of = () =>
                         {
                             _visitor = new CouchQueryParameterVisitor();
                             _visitor.Visit(cmd);
                         };

        It should_have_3_parameters = () => 
            _visitor.Parameters.Cast<CouchDataParameter>().Count().ShouldEqual(3);
    }
}
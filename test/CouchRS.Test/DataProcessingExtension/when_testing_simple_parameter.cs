using System.Linq;
using Machine.Specifications;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class when_testing_simple_parameter : with_couch_db_command
    {
        protected static CouchDataParameterCollection _parameters;

        Because of = () =>
                         {
                             _parameters = (CouchDataParameterCollection)_command.GetParameters();
                         };

        It should_have_one_parameter = () => _parameters.Cast<CouchDataParameter>().Count().ShouldEqual(1);
        It should_have_parameter_named_ParameterA = () => _parameters.Cast<CouchDataParameter>().Count(x => x.ParameterName == "@ParameterA").ShouldEqual(1);
    }
}
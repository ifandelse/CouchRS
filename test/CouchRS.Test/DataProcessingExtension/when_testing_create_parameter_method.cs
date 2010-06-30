using Machine.Specifications;
using Microsoft.ReportingServices.DataProcessing;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class when_testing_create_parameter_method : with_couch_db_command
    {
        protected static IDataParameter _parameter;

        Because of = () =>
                         {
                             _parameter = _command.CreateParameter();
                         };

        private It should_be_of_type_CouchDbParameter = () => _parameter.ShouldBeOfType(typeof (CouchDataParameter));
    }
}
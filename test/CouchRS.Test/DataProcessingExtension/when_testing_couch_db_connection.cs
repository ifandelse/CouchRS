using Machine.Specifications;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class when_testing_couch_db_connection : with_couch_db_connection
    {
        It should_have_a_username_of_SomeUser = () => _connection.UserName.ShouldEqual("SomeUser");
        It should_have_a_password = () => _connection.Password.ShouldEqual("p@ssw0rd");
        It should_have_the_correct_connection_string = () => _connection.ConnectionString.ShouldEqual(@"http://SomeCouchServer:5984/SomeCouchDatabase");
        It should_return_the_correct_transaction_type = () => _connection.BeginTransaction().ShouldBeOfType(typeof(CouchDbTransaction));
        It should_return_the_correct_command_type = () => _connection.CreateCommand().ShouldBeOfType(typeof(CouchDbCommand));
        It should_return_the_correct_CouchUri = () =>
                                                    {
                                                        var uri = _connection.BuildCouchUri();
                                                        uri.DatabaseName.ShouldEqual("SomeCouchDatabase");
                                                        uri.ToString().ShouldEqual(@"http://somecouchserver:5984/SomeCouchDatabase");
                                                    };
        It should_have_a_localized_name_of_Couch_Database_Connection = () => _connection.LocalizedName.ShouldEqual("Couch Database Connection");
    }
}
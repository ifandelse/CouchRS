using Machine.Specifications;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class with_couch_db_connection
    {
        protected static CouchDbConnection _connection;

        Establish context = () =>
                                {
                                    _connection = new CouchDbConnection("http://SomeCouchServer:5984/SomeCouchDatabase")
                                                      {
                                                          Password = "p@ssw0rd",
                                                          UserName = "SomeUser"
                                                      };
                                };
    }
}

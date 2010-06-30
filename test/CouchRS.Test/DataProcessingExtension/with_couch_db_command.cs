using Machine.Specifications;
using Moq;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class with_couch_db_command
    {
        protected static CouchDbCommand _command;

        Establish context = () =>
                                    {
                                        var mockConnection = new Mock<CouchDbConnection>();
                                        mockConnection.Setup(x => x.BuildCouchUri()).Returns(new CouchUri("http", "SomeCouchServer", 5984, "SomeCouchDB"));
                                        _command = new CouchDbCommand(mockConnection.Object)
                                                       {
                                                           CommandText = "FROM VIEW(designDoc, viewName) WITH KEY MyKeyName WHERE MyKeyName = @ParameterA"
                                                       };
                                        _command.Parameters.Add(new CouchDataParameter("@ParameterA", "Blah"));
                                    };
    }
}

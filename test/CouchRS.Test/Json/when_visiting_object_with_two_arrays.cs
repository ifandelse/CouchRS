using Machine.Specifications;
using CouchRS.Json;

namespace LoveSeat.Test.JsonVisitorTests
{
    public class when_visiting_object_with_two_arrays
    {
        protected static JsonVisitor visitor;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();
                                     visitor.Traverse("{foo:['1','2','3'],bar:['A','B']}");
                                 };

        private It should_have_six_records = () => 
                                             visitor.Records.Count.ShouldEqual(6);
    }
}
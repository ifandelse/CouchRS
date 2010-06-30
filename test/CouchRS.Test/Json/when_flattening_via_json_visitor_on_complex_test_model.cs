using LoveSeat.Test.JsonVisitorTests;
using Machine.Specifications;
using CouchRS.Json;

namespace CouchRS.Test.Json
{
    public class when_flattening_via_json_visitor_on_complex_test_model : with_complex_test_model
    {
        private static JsonVisitor visitor;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();
                                     visitor.Traverse(json);
                                 };
        
        private It should_have_34_records = () => 
                                            visitor.Records.Count.ShouldEqual(34);
        
        private It should_have_34_normalized_records = () => 
            visitor.NormalizedRecords.Count.ShouldEqual(34);

        private It should_have_uniform_column_count = () =>
                                                          {
                                                              var columnCount = visitor.NormalizedRecords[0].Count;
                                                              visitor
                                                                  .NormalizedRecords
                                                                  .TrueForAll(x => x.Count == columnCount)
                                                                  .ShouldBeTrue();
                                                          };
    }
}
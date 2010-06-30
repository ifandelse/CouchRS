using System;
using System.Collections.Generic;
using System.Linq;
using LoveSeat.Test.JsonVisitorTests;
using Machine.Specifications;
using CouchRS.Json;

namespace CouchRS.Test.Json
{
    public class when_flattening_json_with_visitor : with_couch_json
    {
        protected static JsonVisitor visitor;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();
                                     visitor.Traverse(json);
                                     var test = "";
                                 };
        
        private It should_have_24_records = () => 
            visitor.Records.Count.ShouldEqual(24);

        private It should_have_24_normalized_records = () => 
            visitor.NormalizedRecords.Count.ShouldEqual(24);

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

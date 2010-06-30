using Machine.Specifications;
using CouchRS.Json;
using System.Linq;
using Symbiote.Core;

namespace CouchRS.Test.Json
{
    public class when_visiting_object_with_one_property_containing_an_array_of_complex_types
    {
        static JsonVisitor visitor;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();
                                     visitor.Traverse("{foo:[{bacon:'sizzle'},{toast:'crunch'}]");
                                 };

        It should_have_two_combinations = () =>
                                          visitor.Records.Count().ShouldEqual(2);

        It should_have_one_key_value_pair = () =>
                                            visitor.Records.First().Count.ShouldEqual(1);

        It should_have_correct_key_value_pair_in_first_combination = () =>
                                                                     visitor.Records
                                                                         .First() //First combination
                                                                         .First().ShouldEqual(Tuple.Create("foo.bacon", "sizzle"));

        It should_have_correct_key_value_pair_in_second_combination = () =>
                                                                      visitor.Records
                                                                          .ElementAt(1) //Second combination
                                                                          .First().ShouldEqual(Tuple.Create("foo.toast", "crunch"));
    }
}
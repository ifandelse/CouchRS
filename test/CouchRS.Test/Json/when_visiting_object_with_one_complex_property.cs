using Machine.Specifications;
using CouchRS.Json;
using Symbiote.Core;
using System.Linq;

namespace CouchRS.Test.Json
{
    public class when_visiting_object_with_one_complex_property
    {
        static JsonVisitor visitor;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();
                                     visitor.Traverse("{foo:{bacon:'sizzle'}");
                                 };

        It should_have_one_combination = () =>
                                         visitor.Records.Count().ShouldEqual(1);

        It should_have_one_key_value_pair = () =>
                                            visitor.Records.First().Count.ShouldEqual(1);

        It should_have_correct_key_value_pair = () =>
                                                visitor.Records
                                                    .First() //First and only combination
                                                    .First().ShouldEqual(Tuple.Create("foo.bacon", "sizzle"));
    }
}
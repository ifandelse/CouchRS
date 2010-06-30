using Machine.Specifications;

namespace CouchRS.Test.DataProcessingExtension
{
    public class when_testing_couch_data_reader : with_couch_data_reader
    {
        It should_have_a_field_count_of_3 = () => _reader.FieldCount.ShouldEqual(3);
        private It should_have_a_field_named_id_at_index_0 = () => _reader.GetName(0).ShouldEqual("id");
        private It should_have_a_field_named_value_dot_Name_at_index_1 = () => _reader.GetName(1).ShouldEqual("value.Name");
        private It should_have_a_field_named_value_dot_FoodChoices_at_index_2 = () => _reader.GetName(2).ShouldEqual("value.FoodChoices");
    }
}
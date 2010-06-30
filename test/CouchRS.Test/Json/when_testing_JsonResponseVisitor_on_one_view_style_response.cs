using System.Collections.Generic;
using Machine.Specifications;

namespace CouchRS.Test.Json
{
    public class when_testing_JsonResponseVisitor_on_one_view_style_response : with_json_response_visitor
    {
        static string _jsonResponse =
            @"{""total_rows"":2,""offset"":0,""rows"":[
        {
            ""id"": ""21a1c389-985d-4960-906d-80f1c25506a2"",
            ""value"": {
                ""Name"": ""Bugs Bunny"",
                ""FoodChoices"": [
                    ""Carrots"",
                    ""Caviar"",
                    ""Cabbage""
                ] 
            } 
        },
        {
            ""id"": ""31a563da-c95c-4a04-a37f-873f59eed0e5"",
            ""value"": {
                ""Name"": ""Tom the Cat"",
                ""FoodChoices"": [
                    ""Mice"",
                    ""Milk"",
                    ""M & Ms""
                ] 
            } 
        } 
    ]
}";

        private static string _expectedResult =
            @"[

        {
            ""id"": ""21a1c389-985d-4960-906d-80f1c25506a2"",
            ""value"": {
                ""Name"": ""Bugs Bunny"",
                ""FoodChoices"": [
                    ""Carrots"",
                    ""Caviar"",
                    ""Cabbage""
                ] 
            } 
        },
        {
            ""id"": ""31a563da-c95c-4a04-a37f-873f59eed0e5"",
            ""value"": {
                ""Name"": ""Tom the Cat"",
                ""FoodChoices"": [
                    ""Mice"",
                    ""Milk"",
                    ""M & Ms""
                ] 
            } 
        } 
    
]";

        Because of = () =>
                                 {
                                     _visitor.VisitJson(new List<string>() {_jsonResponse});
                                 };

        It should_equal_expected_result = () => _visitor.FormattedJson.ShouldEqual(_expectedResult);
    }
}

using System.Text.RegularExpressions;
using Machine.Specifications;
using CouchRS.DataProcessingExtension;

namespace CouchRS.Test.DataProcessingExtension
{
    public class with_couch_data_reader
    {
        static Regex _jsonStripper = new Regex(@"(?<=""rows"":)\[.*\]", RegexOptions.Compiled | RegexOptions.Singleline);
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
        protected static CouchDataReader _reader;

        Establish context = () =>
                                {
                                    var match = _jsonStripper.Match(_jsonResponse);
                                    _reader = new CouchDataReader(match.Success ? match.ToString() : _jsonResponse);
                                };
    }
}
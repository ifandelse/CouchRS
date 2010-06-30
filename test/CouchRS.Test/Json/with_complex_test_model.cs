using Machine.Specifications;
using CouchRS.Test.TestModel;

namespace CouchRS.Test.Json
{
    public abstract class with_complex_test_model
    {
        protected static TestModelHelper helper;
        protected static string json;

        private Establish context = () =>
                                        {
                                            helper = new TestModelHelper();
                                            json = helper.GetTestJson();
                                        };
    }
}
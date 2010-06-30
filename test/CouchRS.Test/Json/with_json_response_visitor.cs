using Machine.Specifications;
using CouchRS.Json;

namespace CouchRS.Test.Json
{
    public class with_json_response_visitor
    {
        protected static JsonResponseVisitor _visitor;

        Establish context = () => _visitor = new JsonResponseVisitor();
    }
}
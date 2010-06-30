using System.Collections.Generic;
using System.Diagnostics;
using LoveSeat.Test.JsonVisitorTests;
using Machine.Specifications;
using CouchRS.Json;

namespace CouchRS.Test.Json
{
    public class when_visiting_insanity : with_insano_graph
    {
        protected static JsonVisitor visitor;
        protected static Stopwatch visitWatch;
        protected static Stopwatch normalizeWatch;
        protected static List<Dictionary<string, string>> normalizedRecords;

        private Because of = () =>
                                 {
                                     visitor = new JsonVisitor();

                                     visitWatch = Stopwatch.StartNew();
                                     visitor.Traverse(json);
                                     visitWatch.Stop();

                                     normalizeWatch = Stopwatch.StartNew();
                                     normalizedRecords = visitor.NormalizedRecords;
                                     normalizeWatch.Stop();
                                 };

        private It should_have_43859_records = () =>
                                                      visitor.Records.Count.ShouldEqual(43859);

        private It should_have_43859_normalized_records = () =>
            normalizedRecords.Count.ShouldEqual(43859);

        private It should_take_visitor_under_400_ms = () => visitWatch.ElapsedMilliseconds.ShouldBeLessThan(400);
        private It should_take_normalization_under_1500_ms = () => normalizeWatch.ElapsedMilliseconds.ShouldBeLessThan(1500);

        private It should_have_uniform_column_count = () =>
        {
            var columnCount = visitor.NormalizedRecords[0].Count;
            normalizedRecords
                .TrueForAll(x => x.Count == columnCount)
                .ShouldBeTrue();
        };
    }

    //public class when_visiting_insanity_fsharp : with_insano_graph
    //{
    //    protected static JsonParser visitor;
    //    protected static IEnumerable<IEnumerable<Tuple<string, string>>> _result;
    //    protected static Stopwatch visitWatch;
    //    protected static Stopwatch normalizeWatch;
    //    protected static List<IEnumerable<Tuple<string, string>>> normalizedRecords;

    //    private Because of = () =>
    //    {
    //        visitor = new JsonParser();

    //        visitWatch = Stopwatch.StartNew();
    //        _result=visitor.Traverse(json);
    //        visitWatch.Stop();

    //        normalizeWatch = Stopwatch.StartNew();
    //        normalizedRecords = _result.ToList();
    //        normalizeWatch.Stop();
    //    };

    //    private It should_have_43859_records = () =>
    //                                                  normalizedRecords.Count.ShouldEqual(43859);

    //    private It should_have_43859_normalized_records = () =>
    //        normalizedRecords.Count.ShouldEqual(43859);

    //    private It should_take_visitor_under_100_ms = () => visitWatch.ElapsedMilliseconds.ShouldBeLessThan(100);
    //    private It should_take_normalization_under_100_ms = () => normalizeWatch.ElapsedMilliseconds.ShouldBeLessThan(400);
    //}
}
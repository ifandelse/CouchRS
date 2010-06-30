using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using CouchRS.DataProcessingExtension;
using CouchRS.Grammar;

namespace CouchRS.Test.QueryParser
{
    public class when_parsing_query_with_a_union
    {
        protected static CouchDbCommand _command;
        protected static List<CouchRequestContainer> _requests;
        private static string _queryText = @"
FROM VIEW(myDesign, MyView)
USING QUERYOPTIONS(Limit=100,Group=True,Reduce=false,Skip=10,Descending=true)
WITH KEY[Bacon,Sizzle,Eggs]
WHERE Bacon = @StartDate AND Sizzle = 'loud' AND (Eggs = 'scrambled' OR Eggs = 'overeasy')

UNION ALL

FROM VIEW(myDesign, MyOtherView)
USING QUERYOPTIONS(GROUP=true, GROUP_LEVEL=3,Include_Docs=true,Inclusive_end=false)
WITH KEY {Foo,Bar}
WHERE Foo='stupid' AND Bar='example'";

        Establish context = () =>
        {
            _command = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = _queryText };
            _command.Parameters.Add(new CouchDataParameter("@Status", null));
            _command.Parameters.Add(new CouchDataParameter("@StartDate", new DateTime(2010, 5, 2)));
            _command.Parameters.Add(new CouchDataParameter("@EndDate", new DateTime(2010, 5, 7)));

        };

        private Because of = () =>
        {
            var visitor = new CouchCommandVisitor();
            visitor.Visit(_command);
            _requests = visitor.Requests;
        };

        private It should_have_two_items = () => _requests.Count.ShouldEqual(3);
        private It should_produce_two_correct_urls = () => _requests
                                                                    .Select(x => x
                                                                        .Uri
                                                                        .ToString())
                                                                        .SequenceEqual(new[]
                                                                                           {
                                                                                               "http://localhost:5984/test/_design/myDesign/_view/MyView?limit=100&group=true&group_level=1&reduce=false&skip=10&descending=true&key=[\"2010-05-02T00:00:00\",\"loud\",\"scrambled\"]",
                                                                                               "http://localhost:5984/test/_design/myDesign/_view/MyView?key=[\"2010-05-02T00:00:00\",\"loud\",\"overeasy\"]",
                                                                                               "http://localhost:5984/test/_design/myDesign/_view/MyOtherView?group=true&group_level=3&include_docs=true&inclusive_end=false&key={\"Foo\":\"stupid\",\"Bar\":\"example\"}"
                                                                                           }).ShouldBeTrue();
    }
}

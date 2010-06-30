using System;
using CouchRS.DataProcessingExtension;
using Machine.Specifications;
using CouchRS.Grammar;

namespace CouchRS.Test
{
    [Subject(typeof(CouchCommandVisitor))]
    public class when_visiting_a_query_with_a_where_clause_not_in_key_list
    {
        protected static CouchDbCommand cmd;
        static Exception exception;

        Establish context = () =>
                            {
                                var query = @"
                        FROM VIEW(projects,view_all)
                        WITH KEY some_number
                        WHERE should='fail'";

                                cmd = new CouchDbCommand(new CouchDbConnection("http://localhost:5984/test")) { CommandText = query };
                            };

        Because of = () =>
                     {
                         var visitor = new CouchCommandVisitor();
                         exception=Catch.Exception(() =>
                                         visitor.Visit(cmd));
                         
                     };

        It should_have_thrown_an_exception = () =>
                                             exception.ShouldNotBeNull();


    }
}
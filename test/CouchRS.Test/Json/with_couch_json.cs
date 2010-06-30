using Machine.Specifications;

namespace LoveSeat.Test.JsonVisitorTests
{
    public abstract class with_couch_json
    {
        protected static string json;

        private Establish context = () =>
                                        {
                                            json =
                                                @"{
    ""total_rows"": 5,
    ""offset"": 0,
    ""rows"": [
        {
            ""id"": ""1b8add28-7dc5-4018-ab87-c6ab3f7ea90a"",
            ""key"": false,
            ""value"": {
                ""_id"": ""1b8add28-7dc5-4018-ab87-c6ab3f7ea90a"",
                ""_rev"": ""1-22d86f95aa24756bbccbd0649c05e223"",
                ""$type"": ""SillyProject.Domain.Models.Project, SillyProject.Domain"",
                ""Priority"": {
                    ""$type"": ""SillyProject.Domain.Models.Priority, SillyProject.Domain"",
                    ""Name"": """"
                },
                ""IsStartDateEstimated"": false,
                ""IsEndDateEstimated"": false,
                ""IsDueDateEstimated"": false,
                ""IsComplete"": false,
                ""QuestionAnswers"": {
                    ""$type"": ""System.Collections.Generic.List`1[[SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib"",
                    ""$values"": [
                        
                    ]
                },
                ""CreatedBy"": """",
                ""DateCreated"": ""2010-06-02T13:59:10.4890299-05:00"",
                ""DateModified"": ""2010-06-02T13:59:10.4890299-05:00"",
                ""$doc_type"": ""Project"",
                ""$doc_relatedIds"": {
                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                }
            }
        },
        {
            ""id"": ""3d20b333-b25d-4fa5-831d-a7abcfb3c14a"",
            ""key"": false,
            ""value"": {
                ""_id"": ""3d20b333-b25d-4fa5-831d-a7abcfb3c14a"",
                ""_rev"": ""1-54d30d1ee0e5616e6b0c3979542133ea"",
                ""$type"": ""SillyProject.Domain.Models.Project, SillyProject.Domain"",
                ""Title"": ""Test14"",
                ""BusinessJustification"": ""Test14"",
                ""Priority"": {
                    ""$type"": ""SillyProject.Domain.Models.Priority, SillyProject.Domain"",
                    ""Name"": ""Medium""
                },
                ""IsStartDateEstimated"": false,
                ""IsEndDateEstimated"": false,
                ""IsDueDateEstimated"": false,
                ""IsComplete"": false,
                ""QuestionAnswers"": {
                    ""$type"": ""System.Collections.Generic.List`1[[SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib"",
                    ""$values"": [
                        
                    ]
                },
                ""CreatedBy"": """",
                ""DateCreated"": ""2010-06-02T13:59:55.8515657-05:00"",
                ""DateModified"": ""2010-06-02T13:59:55.8515657-05:00"",
                ""$doc_type"": ""Project"",
                ""$doc_relatedIds"": {
                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                }
            }
        },
        {
            ""id"": ""3e164c2b-d99b-4dc5-9128-d9d180e8de49"",
            ""key"": false,
            ""value"": {
                ""_id"": ""3e164c2b-d99b-4dc5-9128-d9d180e8de49"",
                ""_rev"": ""1-3e4f00a420211f7fb94927e93b04788e"",
                ""$type"": ""SillyProject.Domain.Models.Project, SillyProject.Domain"",
                ""Priority"": {
                    ""$type"": ""SillyProject.Domain.Models.Priority, SillyProject.Domain"",
                    ""Name"": """"
                },
                ""IsStartDateEstimated"": false,
                ""IsEndDateEstimated"": false,
                ""IsDueDateEstimated"": false,
                ""IsComplete"": false,
                ""QuestionAnswers"": {
                    ""$type"": ""System.Collections.Generic.List`1[[SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib"",
                    ""$values"": [
                        
                    ]
                },
                ""CreatedBy"": """",
                ""DateCreated"": ""2010-06-02T14:00:36.2376039-05:00"",
                ""DateModified"": ""2010-06-02T14:00:36.2376039-05:00"",
                ""$doc_type"": ""Project"",
                ""$doc_relatedIds"": {
                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                }
            }
        },
        {
            ""id"": ""693ccee2-776f-4bd6-b81b-cf0b2f443f7c"",
            ""key"": false,
            ""value"": {
                ""_id"": ""693ccee2-776f-4bd6-b81b-cf0b2f443f7c"",
                ""_rev"": ""1-991e138d9b0196d5049375255de8eb47"",
                ""$type"": ""SillyProject.Domain.Models.Project, SillyProject.Domain"",
                ""Title"": ""test13"",
                ""BusinessJustification"": ""test13"",
                ""Priority"": {
                    ""$type"": ""SillyProject.Domain.Models.Priority, SillyProject.Domain"",
                    ""Name"": ""Low""
                },
                ""IsStartDateEstimated"": false,
                ""IsEndDateEstimated"": false,
                ""IsDueDateEstimated"": false,
                ""IsComplete"": false,
                ""QuestionAnswers"": {
                    ""$type"": ""System.Collections.Generic.List`1[[SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib"",
                    ""$values"": [
                        
                    ]
                },
                ""CreatedBy"": """",
                ""DateCreated"": ""2010-06-02T13:58:11.2861102-05:00"",
                ""DateModified"": ""2010-06-02T13:58:11.2861102-05:00"",
                ""$doc_type"": ""Project"",
                ""$doc_relatedIds"": {
                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                }
            }
        },
        {
            ""id"": ""b4dd05ea-e780-44ad-8b3f-70a60ccb1478"",
            ""key"": false,
            ""value"": {
                ""_id"": ""b4dd05ea-e780-44ad-8b3f-70a60ccb1478"",
                ""_rev"": ""4-f9d13b55ef9ffccd46a4f9407972f9c7"",
                ""$type"": ""SillyProject.Domain.Models.Project, SillyProject.Domain"",
                ""Title"": ""test15"",
                ""BusinessJustification"": ""test15"",
                ""Priority"": {
                    ""$type"": ""SillyProject.Domain.Models.Priority, SillyProject.Domain"",
                    ""Name"": ""Low""
                },
                ""IsStartDateEstimated"": false,
                ""IsEndDateEstimated"": false,
                ""IsDueDateEstimated"": false,
                ""IsComplete"": false,
                ""QuestionAnswers"": {
                    ""$type"": ""System.Collections.Generic.List`1[[SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]], mscorlib"",
                    ""$values"": [
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""adsfasdgasd"",
                                ""Text"": ""gfYes or sdfsNo"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.YesNoAnswer, SillyProject.Domain"",
                                    ""Name"": ""YesNoAnswer"",
                                    ""DisplayName"": ""Yes/No"",
                                    ""Preferred"": true
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T10:56:28.7225416-05:00"",
                                ""DateModified"": ""2010-06-02T10:56:28.7225416-05:00"",
                                ""_id"": ""399efdeb-2319-4c6b-85f3-e2beb64dea44"",
                                ""_rev"": ""1-e5a29e3f0e86d21c4fcb062077ee4ce3"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""on""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""Bacon!"",
                                ""Text"": ""ret"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:50:40.6501624-05:00"",
                                ""DateModified"": ""2010-05-28T14:50:40.6501624-05:00"",
                                ""_id"": ""436e55de-cb6c-4014-82f8-b99d2cdb5500"",
                                ""_rev"": ""1-2b5e191dfba3d3d354384ffef7e3777d"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""Drop Down List"",
                                ""Text"": ""What is your favorite programming language?"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SetValueAnswer, SillyProject.Domain"",
                                    ""Name"": ""SetValueAnswer"",
                                    ""DisplayName"": ""Set Value List"",
                                    ""ValueList"": {
                                        ""$type"": ""System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib"",
                                        ""$values"": [
                                            ""Java"",
                                            ""PHP"",
                                            ""Assembly"",
                                            ""Those are the only languages worth using""
                                        ]
                                    }
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T11:03:02.4043164-05:00"",
                                ""DateModified"": ""2010-06-02T11:03:02.4043164-05:00"",
                                ""_id"": ""4c9f01c1-9160-4eeb-a4f5-76f29173a362"",
                                ""_rev"": ""1-3aaa6bcfd38f17ba31d4d15e2952189a"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""Java""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""yay!"",
                                ""Text"": "":)"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SingleLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""SingleLineTextAnswer"",
                                    ""DisplayName"": ""Single-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""ModifiedBy"": """",
                                ""DateCreated"": ""2010-05-28T15:57:50.768159-05:00"",
                                ""DateModified"": ""2010-05-28T15:58:02.677159-05:00"",
                                ""_id"": ""78766d6a-5930-4a5d-bce2-66b3821d0833"",
                                ""_rev"": ""2-0fce5598d3b741eb058989396c3c9966"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""ertwer"",
                                ""Text"": ""twertwert"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SingleLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""SingleLineTextAnswer"",
                                    ""DisplayName"": ""Single-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-01T14:19:07.9845756-05:00"",
                                ""DateModified"": ""2010-06-01T14:19:07.9845756-05:00"",
                                ""_id"": ""7aba43cf-5c4d-42c6-81c2-14e25d7fe3b8"",
                                ""_rev"": ""1-95bdac7a23b6b117a60e517652117bc0"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""asdfadsf"",
                                ""Text"": ""Rabge"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.DecimalRangeAnswer, SillyProject.Domain"",
                                    ""Name"": ""DecimalRangeAnswer"",
                                    ""DisplayName"": ""Decimal Range"",
                                    ""Preferred"": 234,
                                    ""Min"": 324,
                                    ""Max"": 234,
                                    ""Step"": 234
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T10:59:21.3505416-05:00"",
                                ""DateModified"": ""2010-06-02T10:59:21.3505416-05:00"",
                                ""_id"": ""7e6ab59b-b2a0-4951-ac52-5fb42422d047"",
                                ""_rev"": ""1-1cb03559afc30a6caa4a851ae546b884"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            }
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""Bacon3"",
                                ""Text"": ""kjlhfdkjlhadf"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:51:23.6001624-05:00"",
                                ""DateModified"": ""2010-05-28T14:51:23.6001624-05:00"",
                                ""_id"": ""88c63934-0993-4b96-912a-3c32a58c806e"",
                                ""_rev"": ""1-d75650a223930de31743a9c5db9a8adf"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""asdf"",
                                ""Text"": ""asdfasdf"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SingleLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""SingleLineTextAnswer"",
                                    ""DisplayName"": ""Single-line Answer""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T10:58:43.9785416-05:00"",
                                ""DateModified"": ""2010-06-02T10:58:43.9785416-05:00"",
                                ""_id"": ""8d333814-0229-4ebf-b909-a85d2d61ab1a"",
                                ""_rev"": ""1-aa848f0d9fdde250d60201a9bbb9edcf"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""asdfadsf"",
                                ""Text"": ""Multi"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T10:51:32.4375416-05:00"",
                                ""DateModified"": ""2010-06-02T10:51:32.4375416-05:00"",
                                ""_id"": ""908283aa-953d-4182-9ed2-ba12816e6d4f"",
                                ""_rev"": ""1-90891fdbbd014500c80077728f859331"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""est""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""trjuetyj"",
                                ""Text"": ""jtyujty"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:53:17.0591624-05:00"",
                                ""DateModified"": ""2010-05-28T14:53:17.0591624-05:00"",
                                ""_id"": ""976c711d-3f3a-44c9-9ee9-cb6de57a722f"",
                                ""_rev"": ""1-a07287b2aecc86eddc0f4984ef0cb32c"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""asdfasdf"",
                                ""Text"": ""Thirdsd"",
                                ""IsUsedForScoring"": true,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SetValueAnswer, SillyProject.Domain"",
                                    ""Name"": ""SetValueAnswer"",
                                    ""DisplayName"": ""Set Value List"",
                                    ""ValueList"": {
                                        ""$type"": ""System.Collections.Generic.List`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib"",
                                        ""$values"": [
                                            ""first"",
                                            ""second"",
                                            ""third""
                                        ]
                                    }
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-06-02T11:01:04.2945416-05:00"",
                                ""DateModified"": ""2010-06-02T11:01:04.2945416-05:00"",
                                ""_id"": ""9a85a13a-be0f-4321-87a7-3bae5c0de4ed"",
                                ""_rev"": ""1-bd0272738f6657666c98ed76e9a7224b"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""first""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""dyjtdy"",
                                ""Text"": ""jgjfgfgj"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:58:38.1721624-05:00"",
                                ""DateModified"": ""2010-05-28T14:58:38.1721624-05:00"",
                                ""_id"": ""b758358a-8bca-4d21-b981-65fa1ebb5297"",
                                ""_rev"": ""1-cd5ed6e5fdade98c30aa576e2bea06fd"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""wpooooo"",
                                ""Text"": ""yjy"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SingleLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""SingleLineTextAnswer"",
                                    ""DisplayName"": ""Single-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T15:02:56.1531624-05:00"",
                                ""DateModified"": ""2010-05-28T15:02:56.1531624-05:00"",
                                ""_id"": ""c3ab35cf-54de-450c-a08b-2dfe7e6669b6"",
                                ""_rev"": ""1-2eea7da816658ac65cce302460ede58f"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""tyjf"",
                                ""Text"": ""hyjghmjgh"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.MultiLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""MultiLineTextAnswer"",
                                    ""DisplayName"": ""Multi-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:54:06.0001624-05:00"",
                                ""DateModified"": ""2010-05-28T14:54:06.0001624-05:00"",
                                ""_id"": ""c48c5451-f861-4a19-bb3c-5b5ab3b076b5"",
                                ""_rev"": ""1-5e5052698a450e4789f6d5a17777abcd"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""est""
                        },
                        {
                            ""$type"": ""SillyProject.Domain.Models.QuestionAnswer, SillyProject.Domain"",
                            ""Question"": {
                                ""$type"": ""SillyProject.Domain.Models.Question, SillyProject.Domain"",
                                ""Name"": ""Test"",
                                ""Text"": ""Test"",
                                ""IsUsedForScoring"": false,
                                ""AnswerMetadata"": {
                                    ""$type"": ""SillyProject.Domain.Models.SingleLineTextAnswer, SillyProject.Domain"",
                                    ""Name"": ""SingleLineTextAnswer"",
                                    ""DisplayName"": ""Single-line Text""
                                },
                                ""IsEnabled"": true,
                                ""CreatedBy"": """",
                                ""ModifiedBy"": """",
                                ""DateCreated"": ""2010-05-28T14:09:08.9671687-05:00"",
                                ""DateModified"": ""2010-05-28T14:22:53.9673266-05:00"",
                                ""_id"": ""e38a8b1f-016a-4fb3-a6b8-11b72ea357f1"",
                                ""_rev"": ""2-d54ade72f3adf47008c21b5752802f9a"",
                                ""$doc_type"": ""Question"",
                                ""$doc_relatedIds"": {
                                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                                },
                                ""_attachments"": {
                                    
                                }
                            },
                            ""Answer"": ""test""
                        }
                    ]
                },
                ""CreatedBy"": """",
                ""DateCreated"": ""2010-06-02T14:08:48.6488401-05:00"",
                ""DateModified"": ""2010-06-02T14:08:48.6488401-05:00"",
                ""$doc_type"": ""Project"",
                ""$doc_relatedIds"": {
                    ""$type"": ""System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Object[], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib""
                }
            }
        }
    ]
}";
                                        };
    }
}
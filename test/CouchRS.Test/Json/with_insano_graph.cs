using Machine.Specifications;

namespace LoveSeat.Test.JsonVisitorTests
{
    public abstract class with_insano_graph
    {
        protected static string json;

        private Establish context = () => json =
                                          @"{
    fuh: 'terp',
    foo: [
        {
            bar: 'A',
            baz: ['1','2','3'],
            bacon: {
                property: 'thingy',
                stuff: ['bears','beats','battlestar galactica']
            }
        },
        {
            bar: 'B',
            baz: ['4','5']
        },
        {
            bar: 'C',
            baz: ['7','8','9','10'],
            frunk: [],
            bacon: {
                property: 'thingy 2',
                stuff: ['do','re','mi'],
                nonsense: [
                    {
                        crap: 'A',
                        crud: 'B',
                        cruft: ['1','2','3'],
                        this_old_man: {
                            he: {
                                played: {
                                    count: ['1','2','3','4'],
                                    on: ['something that rhymes with one?','shoe','knee','door'],
                                    owner: ['anyone?','my','his','my']
                                }
                            }                            
                        }                        
                    },
                    {
                        crap: 'C',
                        crud: 'D',
                        cruft: ['4','5','6']
                    }
                ]
            }
        },
        {
            bar: 'C',
            baz: ['7','8','9','10'],
            frunk: [],
            bacon: {
                property: 'thingy 2',
                stuff: ['do','re','mi'],
                nonsense: [
                    {
                        crap: 'A',
                        crud: 'B',
                        cruft: ['1','2','3'],
                        this_old_man: {
                            street_address1: '',
                            street_address2: '',
                            street_address3: '',
                            city: '',
                            state: '',
                            zip: '',
                            phone: '',
                            cell: '',
                            email: '',
                            blog: '',
                            he: {
                                played: {
                                    count: ['1','2','3','4'],
                                    on: ['something that rhymes with one?','shoe','knee','door'],
                                    owner: ['anyone?','my','his','my']
                                }
                            },
                            wives: [
                                {
                                    name: 'eva',
                                    age: '86',
                                    street_address1: '',
                                    street_address2: '',
                                    street_address3: '',
                                    city: '',
                                    state: '',
                                    zip: '',
                                    phone: '',
                                    cell: '',
                                    email: '',
                                    blog: '',
                                    kids: [
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                    ]   
                                },
                                {
                                    name: 'zsa-zsa',
                                    age: '100',
                                    street_address1: '',
                                    street_address2: '',
                                    street_address3: '',
                                    city: '',
                                    state: '',
                                    zip: '',
                                    phone: '',
                                    cell: '',
                                    email: '',
                                    blog: '',
                                    kids: [
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                    ]
                                },
                                {
                                    name: 'elizabeth',
                                    age: '96',
                                    street_address1: '',
                                    street_address2: '',
                                    street_address3: '',
                                    city: '',
                                    state: '',
                                    zip: '',
                                    phone: '',
                                    cell: '',
                                    email: '',
                                    blog: '',
                                    kids: [
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                        {
                                            name: '',
                                            age: '',
                                            street_address1: '',
                                            street_address2: '',
                                            street_address3: '',
                                            city: '',
                                            state: '',
                                            zip: '',
                                            phone: '',
                                            cell: '',
                                            email: '',
                                            blog: '',
                                            vehicles:[
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                },
                                                {
                                                    make: '',
                                                    model: '',
                                                    year: '',
                                                    type: ''
                                                }                                                
                                            ]
                                        },
                                    ]
                                }
                            ]                        
                        }                        
                    },
                    {
                        crap: 'C',
                        crud: 'D',
                        cruft: ['4','5','6']
                    }
                ]
            }
        }
    ]
}";
    }
}
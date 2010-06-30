using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CouchRS.Test.TestModel
{
    public class TestModelHelper
    {
        public string GetTestJson()
        {
            string json = "";
            json = JsonConvert.SerializeObject(GetTestOrders());
            return json;
        }

        private object GetTestOrders()
        {
            var orders = new List<Order>()
                             {
                                 new Order()
                                     {
                                         Customer = new Customer()
                                                        {
                                                            CustomerName = "Josh Bush",
                                                            CustomerNumber = "123"
                                                        },
                                        OrderNumber = "100",
                                        PurchaseOrder = "JBush",
                                        ShippingAddress = new ShippingAddress()
                                                              {
                                                                  AddressLine1 = "725 Cool Springs Blvd.",
                                                                  AddressLine2 = "Ste 320",
                                                                  City = "Franklin",
                                                                  State = "TN",
                                                                  Zip = "37067"
                                                              },
                                        LineItems = new List<OrderLineItem>()
                                                        {
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "HTC Incredible",
                                                                    ProductNumber = "HTC123",
                                                                    Quantity = 1,
                                                                    ProductCost = 200m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "UPS",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "987654321"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 18.41m
                                                                                        }
                                                                                }
                                                                },
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "Jawbone Bluetooth Handsfree",
                                                                    ProductNumber = "JBT123",
                                                                    Quantity = 1,
                                                                    ProductCost = 49m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "Fedex",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "444333222111"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 3.78m
                                                                                        }
                                                                                }
                                                                }
                                                        },
                                            Invoice = new Invoice()
                                                          {
                                                              LineItems = new List<InvoiceLineItem>()
                                                                              {
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "HTC Incredible",
                                                                                          ProductNumber = "HTC123",
                                                                                          ProductCost = 200m,
                                                                                          Taxes = 18.41m
                                                                                      },
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "Jawbone Bluetooth Handsfree",
                                                                                          ProductNumber = "JBT123",
                                                                                          ProductCost = 49m,
                                                                                          Taxes = 3.78m
                                                                                      }
                                                                              },
                                                                Payments = new List<Payment>()
                                                                               {
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("3/1/2010"),
                                                                                           Amount = 150m
                                                                                       },
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("4/1/2010"),
                                                                                           Amount = 35m
                                                                                       }
                                                                               }
                                                          }
                                     },
                                     new Order()
                                     {
                                         Customer = new Customer()
                                                        {
                                                            CustomerName = "Jim Cowart",
                                                            CustomerNumber = "456"
                                                        },
                                        OrderNumber = "101",
                                        PurchaseOrder = "Cowart",
                                        ShippingAddress = new ShippingAddress()
                                                              {
                                                                  AddressLine1 = "2950 Buckner Lane",
                                                                  AddressLine2 = "",
                                                                  City = "Spring Hill",
                                                                  State = "TN",
                                                                  Zip = "37174"
                                                              },
                                        LineItems = new List<OrderLineItem>()
                                                        {
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "HTC Incredible",
                                                                    ProductNumber = "HTC123",
                                                                    Quantity = 1,
                                                                    ProductCost = 200m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "UPS",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "1ZBlahBlahBlah"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 18.41m
                                                                                        }
                                                                                }
                                                                },
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "Jawbone Bluetooth Handsfree",
                                                                    ProductNumber = "JBT123",
                                                                    Quantity = 1,
                                                                    ProductCost = 49m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "Fedex",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "8675309"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 3.78m
                                                                                        }
                                                                                }
                                                                },
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "HTC Incredible Auto Mount",
                                                                    ProductNumber = "HTCAM987",
                                                                    Quantity = 1,
                                                                    ProductCost = 23.46m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "Fedex",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "6155551212"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 2.43m
                                                                                        }
                                                                                }
                                                                }
                                                        },
                                            Invoice = new Invoice()
                                                          {
                                                              LineItems = new List<InvoiceLineItem>()
                                                                              {
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "HTC Incredible",
                                                                                          ProductNumber = "HTC123",
                                                                                          ProductCost = 200m,
                                                                                          Taxes = 18.41m
                                                                                      },
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "Jawbone Bluetooth Handsfree",
                                                                                          ProductNumber = "JBT123",
                                                                                          ProductCost = 49m,
                                                                                          Taxes = 3.78m
                                                                                      },
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "HTC Incredible Auto Mount",
                                                                                          ProductNumber = "HTCAM987",
                                                                                          ProductCost = 23.46m,
                                                                                          Taxes = 2.43m
                                                                                      }
                                                                              },
                                                                Payments = new List<Payment>()
                                                                               {
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("5/1/2010"),
                                                                                           Amount = 75.75m
                                                                                       },
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("6/1/2010"),
                                                                                           Amount = 75.25m
                                                                                       }
                                                                               }
                                                          }
                                     },new Order()
                                     {
                                         Customer = new Customer()
                                                        {
                                                            CustomerName = "Alex Robson",
                                                            CustomerNumber = "007"
                                                        },
                                        OrderNumber = "99",
                                        PurchaseOrder = "DROID!",
                                        ShippingAddress = new ShippingAddress()
                                                              {
                                                                  AddressLine1 = "725 Cool Springs Blvd.",
                                                                  AddressLine2 = "Ste 320",
                                                                  City = "Franklin",
                                                                  State = "TN",
                                                                  Zip = "37067"
                                                              },
                                        LineItems = new List<OrderLineItem>()
                                                        {
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "Motorola Droid",
                                                                    ProductNumber = "MD333",
                                                                    Quantity = 1,
                                                                    ProductCost = 259.99m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "UPS",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "357951654"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 24.32m
                                                                                        }
                                                                                }
                                                                },
                                                            new OrderLineItem()
                                                                {
                                                                    ProductName = "Jawbone Bluetooth Handsfree",
                                                                    ProductNumber = "JBT123",
                                                                    Quantity = 1,
                                                                    ProductCost = 49m,
                                                                    Shipments = new List<Shipment>()
                                                                                    {
                                                                                        new Shipment()
                                                                                            {
                                                                                                Carrier = "Fedex",
                                                                                                Quantity = 1,
                                                                                                TrackingNumber = "444333222111"
                                                                                            }
                                                                                    },
                                                                    Taxes = new List<OrderLineItemTax>()
                                                                                {
                                                                                    new OrderLineItemTax()
                                                                                        {
                                                                                            TaxAuthority = "TN",
                                                                                            Amount = 3.78m
                                                                                        }
                                                                                }
                                                                }
                                                        },
                                            Invoice = new Invoice()
                                                          {
                                                              LineItems = new List<InvoiceLineItem>()
                                                                              {
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "Motorola Droid",
                                                                                          ProductNumber = "MD333",
                                                                                          ProductCost = 259.99m,
                                                                                          Taxes = 24.32m
                                                                                      },
                                                                                  new InvoiceLineItem()
                                                                                      {
                                                                                          ProductName = "Jawbone Bluetooth Handsfree",
                                                                                          ProductNumber = "JBT123",
                                                                                          ProductCost = 49m,
                                                                                          Taxes = 3.78m
                                                                                      }
                                                                              },
                                                                Payments = new List<Payment>()
                                                                               {
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("3/1/2010"),
                                                                                           Amount = 150m
                                                                                       },
                                                                                   new Payment()
                                                                                       {
                                                                                           PaymentDate = DateTime.Parse("4/1/2010"),
                                                                                           Amount = 54.61m
                                                                                       }
                                                                               },
                                                                Adjustments = new List<InvoiceAdjustment>()
                                                                                  {
                                                                                      new InvoiceAdjustment()
                                                                                          {
                                                                                              Description = "Cause I said so...",
                                                                                              Amount = -89m
                                                                                          }
                                                                                  }
                                                          }
                                     },
                             };

            return new
                       {
                           total_rows = 3,
                           rows = orders
                       };
        }
    }
}
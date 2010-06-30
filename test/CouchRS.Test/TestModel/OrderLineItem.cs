using System.Collections.Generic;
using System.Linq;

namespace CouchRS.Test.TestModel
{
    public class OrderLineItem
    {
        public OrderLineItem()
        {
            Taxes = new List<OrderLineItemTax>();
            Shipments = new List<Shipment>();
        }

        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public decimal ProductCost { get; set; }
        public IList<OrderLineItemTax> Taxes { get; set; }
        public int Quantity { get; set; }
        public decimal TotalLineCost
        {
            get
            {
                return ProductCost + Taxes.Sum(x => x.Amount);
            }
        }
        public IList<Shipment> Shipments { get; set; }
    }
}
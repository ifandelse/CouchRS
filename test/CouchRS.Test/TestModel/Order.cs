using System.Collections.Generic;

namespace CouchRS.Test.TestModel
{
    public class Order
    {
        public Order()
        {
            LineItems = new List<OrderLineItem>();
        }

        public Customer Customer { get; set; }
        public string OrderNumber { get; set; }
        public string PurchaseOrder { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public Invoice Invoice { get; set; }
        public IList<OrderLineItem> LineItems { get; set; }
    }
}

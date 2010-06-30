using System.Collections.Generic;
using System.Linq;

namespace CouchRS.Test.TestModel
{
    public class Invoice
    {
        public Invoice()
        {
            LineItems = new List<InvoiceLineItem>();
            Adjustments = new List<InvoiceAdjustment>();
            Payments = new List<Payment>();
        }

        public IList<InvoiceLineItem> LineItems { get; set; }
        public IList<InvoiceAdjustment> Adjustments { get; set; }
        public IList<Payment> Payments { get; set; }

        public decimal BalanceDue
        {
            get
            {
                return InvoiceAmount - TotalPaid;
            }
        }

        public decimal InvoiceAmount
        {
            get
            {
                return LineItems.Sum(x => x.ProductCost + x.Taxes) + Adjustments.Sum(x => x.Amount);
            }    
        }

        public bool IsOverPaid
        {
            get
            {
                return TotalPaid > InvoiceAmount;
            }
        }

        public bool IsPaidInFull
        {
            get
            {
                return TotalPaid >= InvoiceAmount;
            }
        }

        public decimal TotalPaid
        {
            get
            {
                return Payments.Count == 0 ? 0 : Payments.Sum(x => x.Amount);
            }
        }
    }
}
using System;

namespace QuantIREnergy2.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Participant { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public decimal TotalNetCharge { get; set; }
    }
}

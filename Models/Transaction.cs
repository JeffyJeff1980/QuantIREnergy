using System;

namespace QuantIREnergy2.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Balance { get; set; }
    }

    public enum TransactionType
    {
        Debit, Credit
    }
}

using System.Collections.Generic;

namespace QuantIREnergy2.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public AccountType Type { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public enum Currency
    {
        CAD, USD
    }

    public enum AccountType
    {
        Investment, Checking, Savings
    }
}

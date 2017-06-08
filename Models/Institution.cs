using System.Collections.Generic;

namespace QuantIREnergy2.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public InstitutionType Type { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }

    public enum InstitutionType
    {
        Bank, Market
    }
}

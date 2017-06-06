namespace QuantIREnergy2.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
    }

    public enum TransactionType
    {
        Bid, Offer
    }
}

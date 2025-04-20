namespace CodeChallengeApp.Domain.Entities
{
    public enum TransactionTypeEnum
    {
        Debit,
        Credit
    }

    public class Transaction
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


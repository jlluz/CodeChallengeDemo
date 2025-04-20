using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
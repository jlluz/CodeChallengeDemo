namespace CodeChallengeApp.Domain.Entities
{
    public class User
    {
        public required string UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}

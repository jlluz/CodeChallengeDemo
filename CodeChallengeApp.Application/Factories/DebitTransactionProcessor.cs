using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Factories
{
    public class DebitTransactionProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            // Debit-specific processing logic.
            Console.WriteLine($"Processing debit transaction: {transaction.Id} for user {transaction.UserId}");
        }
    }
}


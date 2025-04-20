using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Factories
{
    public class CreditTransactionProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            // Credit-specific processing logic.
            Console.WriteLine($"Processing credit transaction: {transaction.Id} for user {transaction.UserId}");
        }
    }
}


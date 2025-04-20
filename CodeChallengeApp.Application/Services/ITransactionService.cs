using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Application.Services
{
    public interface ITransactionService
    {
        Task<Dictionary<string, decimal>> GetTotalAmountPerUserAsync();
        Task<Dictionary<TransactionTypeEnum, decimal>> GetTotalAmountByTransactionTypeAsync();
        Task<List<Transaction>> GetHighVolumeTransactionsAsync(decimal threshold);
        Task<Transaction> ProcessAndAddTransactionAsync(Transaction transaction);
    }
}


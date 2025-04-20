using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<List<Transaction>> GetTransactionsAsync();
        Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId);
    }
}


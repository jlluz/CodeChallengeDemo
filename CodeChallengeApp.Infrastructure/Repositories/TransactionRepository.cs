using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallengeApp.Infrastructure.Data;
using CodeChallengeApp.Infrastructure.Repositories;
using CodeChallengeApp.Domain.Entities;

namespace CodeChallengeApp.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId)
        {
            return await _context.Transactions
                 .Where(t => t.UserId == userId)
                 .ToListAsync();
        }
    }
}

using CodeChallengeApp.Application.Factories;
using CodeChallengeApp.Domain.Entities;
using CodeChallengeApp.Infrastructure.Repositories;

namespace CodeChallengeApp.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionProcessorFactory _processorFactory;

        public TransactionService(
            ITransactionRepository transactionRepository,
            ITransactionProcessorFactory processorFactory)
        {
            _transactionRepository = transactionRepository;
            _processorFactory = processorFactory;
        }

        public async Task<Transaction> ProcessAndAddTransactionAsync(Transaction transaction)
        {
            var processor = _processorFactory.GetProcessor(transaction.TransactionType);
            processor.Process(transaction);
            var addedTransaction = await _transactionRepository.AddTransactionAsync(transaction);
            return addedTransaction;
        }

        public async Task<Dictionary<string, decimal>> GetTotalAmountPerUserAsync()
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            return transactions.GroupBy(t => t.UserId)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }

        public async Task<Dictionary<TransactionTypeEnum, decimal>> GetTotalAmountByTransactionTypeAsync()
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            return transactions.GroupBy(t => t.TransactionType)
                .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));
        }

        public async Task<List<Transaction>> GetHighVolumeTransactionsAsync(decimal threshold)
        {
            var transactions = await _transactionRepository.GetTransactionsAsync();
            return transactions.Where(t => t.Amount > threshold).ToList();
        }
    }
}


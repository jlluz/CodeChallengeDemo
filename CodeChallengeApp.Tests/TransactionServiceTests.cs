using CodeChallengeApp.Application.Factories;
using CodeChallengeApp.Application.Services;
using CodeChallengeApp.Domain.Entities;
using CodeChallengeApp.Infrastructure.Data;
using CodeChallengeApp.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

using Xunit;

namespace CodeChallengeApp.Tests
{
    /// <summary>
    /// Unit tests for the TransactionService class.
    /// Uses an in-memory database to simulate database operations.
    /// </summary>
    public class TransactionServiceTests : IDisposable
    {
        // In-memory database context for testing.
        private readonly AppDbContext _context;

        // Repository for transaction operations.
        private readonly ITransactionRepository _transactionRepository;

        // Factory instance used by the service.
        private readonly ITransactionProcessorFactory _processorFactory;

        // The service under test.
        private readonly ITransactionService _transactionService;

        public TransactionServiceTests()
        {
            // Arrange: Set up a new in-memory database with a unique name.
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new AppDbContext(options);

            // Instantiate the repository and factory using the in-memory context.
            _transactionRepository = new TransactionRepository(_context);
            _processorFactory = new TransactionProcessorFactory();

            // Create the business service using the repository and factory.
            _transactionService = new TransactionService(_transactionRepository, _processorFactory);
        }

        /// <summary>
        /// Verifies that when a transaction is processed and added, it is saved correctly.
        /// </summary>
        [Fact]
        public async Task ProcessAndAddTransactionAsync_Should_Add_Transaction()
        {
            // Arrange: Create a sample transaction.
            var transaction = new Transaction
            {
                UserId = "Joao1",
                Amount = 150m,
                TransactionType = TransactionTypeEnum.Credit,
                CreatedAt = DateTime.Now
            };

            // Act: Process and add the transaction using the service.
            var addedTransaction = await _transactionService.ProcessAndAddTransactionAsync(transaction);

            // Assert: Retrieve transactions and verify the added transaction exists.
            var transactionsInDb = await _context.Transactions.ToListAsync();
            Assert.NotNull(addedTransaction);
            Assert.Single(transactionsInDb);
            Assert.Equal("Joao1", transactionsInDb.First().UserId);
            Assert.Equal(150m, transactionsInDb.First().Amount);
        }

        /// <summary>
        /// Verifies that the service correctly aggregates the total transaction amount per user.
        /// </summary>
        [Fact]
        public async Task GetTotalAmountPerUserAsync_Should_Return_Correct_Total()
        {
            // Arrange: Seed two transactions for the same user.
            string userId = "Joao1";
            await _transactionRepository.AddTransactionAsync(new Transaction
            {
                UserId = userId,
                Amount = 100m,
                TransactionType = TransactionTypeEnum.Debit,
                CreatedAt = DateTime.Now
            });
            await _transactionRepository.AddTransactionAsync(new Transaction
            {
                UserId = userId,
                Amount = 200m,
                TransactionType = TransactionTypeEnum.Credit,
                CreatedAt = DateTime.Now
            });

            // Act: Calculate the total amount for the user.
            var totals = await _transactionService.GetTotalAmountPerUserAsync();

            // Assert: Verify that the aggregated amount equals the expected total.
            Assert.True(totals.ContainsKey(userId));
            Assert.Equal(300m, totals[userId]);
        }

        /// <summary>
        /// Disposes the in-memory database context after each test.
        /// </summary>
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}

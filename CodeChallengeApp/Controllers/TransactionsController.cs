using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CodeChallengeApp.Domain.Entities;
using CodeChallengeApp.Application.DTOs;
using CodeChallengeApp.Application.Services;

namespace CodeChallengeApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var transaction = _mapper.Map<Transaction>(transactionDto);
            var addedTransaction = await _transactionService.ProcessAndAddTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransactionById), new { id = addedTransaction.Id }, addedTransaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            // For demonstration, we'll fetch all transactions and return the matching ID.
            var transactions = await _transactionService.GetHighVolumeTransactionsAsync(0);
            var transaction = transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            // Placeholder implementation - adjust as needed.
            var totals = await _transactionService.GetTotalAmountPerUserAsync();
            return Ok(totals);
        }

        [HttpGet("totals-per-user")]
        public async Task<IActionResult> GetTotalsPerUser()
        {
            var totals = await _transactionService.GetTotalAmountPerUserAsync();
            return Ok(totals);
        }

        [HttpGet("totals-by-type")]
        public async Task<IActionResult> GetTotalsByType()
        {
            var totals = await _transactionService.GetTotalAmountByTransactionTypeAsync();
            return Ok(totals);
        }

        [HttpGet("high-volume")]
        public async Task<IActionResult> GetHighVolumeTransactions([FromQuery] decimal threshold)
        {
            var transactions = await _transactionService.GetHighVolumeTransactionsAsync(threshold);
            return Ok(transactions);
        }
    }
}

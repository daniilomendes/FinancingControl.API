using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
using FinancialControl.Services.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancingControl.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTransactionDto transaction)
        {
            try
            {
                var transactionCreated = _transactionService.Add(transaction);
                return Ok(transactionCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactions();
                return Ok(transactions);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

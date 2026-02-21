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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Transaction transaction = _transactionService.GetById(id);
                return Ok(transaction);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/type/{type}")]
        public IActionResult GetTransactionsByType(string type)
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactionsByType(type);
                return Ok(transactions);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            try
            {
                var transactions = _transactionService.GetBalance();
                return Ok(transactions);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/balance/type/{type}")]
        public IActionResult GetBalanceByType(string type)
        {
            try
            {
                var transactions = _transactionService.GetBalanceByType(type);
                return Ok(transactions);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
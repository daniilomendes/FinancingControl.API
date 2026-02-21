using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
using FinancialControl.Models.Response;
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
                return Ok(ApiResponse<Transaction>.Success(transactionCreated));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<Transaction>.Failure(ex.Message));
            }
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactions();
                return Ok(ApiResponse<List<Transaction>>.Success(transactions));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ApiResponse<Transaction>.Failure(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Transaction transaction = _transactionService.GetById(id);
                return Ok(ApiResponse<Transaction>.Success(transaction));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ApiResponse<Transaction>.Failure(ex.Message));
            }
        }

        [HttpGet("/type/{type}")]
        public IActionResult GetTransactionsByType(string type)
        {
            try
            {
                List<Transaction> transactions = _transactionService.GetTransactionsByType(type);
                return Ok(ApiResponse<List<Transaction>>.Success(transactions));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ApiResponse<Transaction>.Failure(ex.Message));
            }
        }

        [HttpGet("/balance")]
        public IActionResult GetBalance()
        {
            try
            {

                var transactions = _transactionService.GetBalance();
                return Ok(ApiResponse<TransactionBalance>.Success(transactions));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ApiResponse<TransactionBalance>.Failure(ex.Message));
            }
        }

        [HttpGet("/balance/type/{type}")]
        public IActionResult GetBalanceByType(string type)
        {
            try
            {
                var transactions = _transactionService.GetBalanceByType(type);
                return Ok(ApiResponse<TransactionBalance>.Success(transactions));
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ApiResponse<TransactionBalance>.Failure(ex.Message));
            }
        }
    }
}
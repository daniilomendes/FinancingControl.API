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
        public IActionResult Create([FromBody] Transaction transaction)
        {
            var transactionCreated = _transactionService.Add(transaction);
            return Ok(transactionCreated);
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            List<Transaction> transactions = _transactionService.GetTransactions();
            return Ok(transactions);
        }
    }
}

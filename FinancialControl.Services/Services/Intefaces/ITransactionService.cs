
using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;

namespace FinancialControl.Services.Services.Intefaces
{
    public interface ITransactionService
    {
        Transaction Add(CreateTransactionDto transacrion);
        List<Transaction> GetTransactions();
        Transaction GetById(int id);
    }
}

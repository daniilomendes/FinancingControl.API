
using FinancialControl.Models.Entities;

namespace FinancialControl.Services.Services.Intefaces
{
    public interface ITransactionService
    {
        Transaction Add(Transaction transacrion);
        List<Transaction> GetTransactions();

    }
}

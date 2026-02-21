using FinancialControl.Models.Entities;
using FinancialControl.Services.Services.Intefaces;

namespace FinancialControl.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly List<Transaction> _transactions = new();

        public Transaction Add(Transaction transacrion)
        {
            _transactions.Add(transacrion);
            return transacrion;
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}

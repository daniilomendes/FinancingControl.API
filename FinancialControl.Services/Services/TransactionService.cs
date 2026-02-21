using FinancialControl.Models.DTOs;
using FinancialControl.Models.Entities;
using FinancialControl.Services.Services.Intefaces;

namespace FinancialControl.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly List<Transaction> _transactions = new();

        public Transaction Add(CreateTransactionDto transacrionDTO)
        {
            if (transacrionDTO.Amount <= 0)
            {
                throw new ArgumentException("O valor deve ser maior que zero.");
            }

            Transaction newTransaction = new(transacrionDTO.Description, transacrionDTO.Amount, transacrionDTO.Type);

            _transactions.Add(newTransaction);
            return newTransaction;
        }

        public List<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}

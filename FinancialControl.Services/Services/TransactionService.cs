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
            if (!_transactions.Any())
            {
                throw new InvalidOperationException("Nenhuma transação registrada até o momento.");
            }

            return _transactions;
        }

        public Transaction GetById(int id)
        {
            Transaction transaction = _transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Transação não encontrada.");
            }

            return transaction;
        }

        public List<Transaction> GetTransactionsByType(string type)
        {
            List<Transaction> transactions = _transactions.Where(x => x.Type.Equals(type)).ToList();

            if (!transactions.Any())
            {
                throw new InvalidOperationException("Nenhuma transação não encontrada.");
            }

            return transactions;
        }
    }
}

namespace FinancialControl.Models.DTOs
{
    public class CreateTransactionDto
    {
        public required double Amount { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
    }
}

using Domain.Enums;

namespace Application.Features.Transactions.Queries.GetTransactionsList
{
    public class TransactionsDto
    {
        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Narration { get; set; }
        public ETransactionType TransactionType { get; set; }
        public string FromAcct { get; set; }
        public string ToAcct { get; set; }
        public ETransactionStatus Status { get; set; } = ETransactionStatus.PENDING;
        public ETransactionChannel TransactionChannel { get; set; }
    }
}

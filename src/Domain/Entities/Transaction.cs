using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Transaction : AuditableEntity
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

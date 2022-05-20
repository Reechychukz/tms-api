using Domain.Enums;
using MediatR;

namespace Application.Features.Transactions.Commands.InitiateTransaction
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        //Parent Id
        public Guid AccountId { get; set; }
        public double Amount { get; set; }
        public string Narration { get; set; }
        public ETransactionType TransactionType { get; set; }
        public string FromAcct { get; set; }
        public string ToAcct { get; set; }
        public ETransactionStatus Status { get; set; } = ETransactionStatus.PENDING;
        public ETransactionChannel TransactionChannel { get; set; }
    }
}

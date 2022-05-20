using MediatR;

namespace Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

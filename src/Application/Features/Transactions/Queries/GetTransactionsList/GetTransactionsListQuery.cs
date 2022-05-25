using Application.Features.Transactions.Queries.GetTransactionsList;
using MediatR;

namespace Application.Features.Transactions.Queries
{
    public class GetTransactionsListQuery : IRequest<List<TransactionsDto>>
    {
        public string Sender { get; set; }

        public GetTransactionsListQuery(string sender)
        {
            Sender = Sender ?? throw new ArgumentNullException(nameof(sender));
        }
    }
}

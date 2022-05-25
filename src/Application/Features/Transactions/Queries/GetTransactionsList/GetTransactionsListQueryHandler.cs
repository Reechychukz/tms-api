using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, List<TransactionsDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsListQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TransactionsDto>> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var transactionList = await _transactionRepository.GetTransactionsBySender(request.Sender);
            return _mapper.Map<List<TransactionsDto>>(transactionList);
        }
    }
}

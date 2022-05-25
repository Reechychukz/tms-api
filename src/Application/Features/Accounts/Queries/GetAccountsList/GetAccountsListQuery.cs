using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQuery : IRequest<List<AccountsDto>>
    {
        public Guid CustomerId { get; set; }

        public GetAccountsListQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, List<AccountsDto>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountsListQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<List<AccountsDto>> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
        {
            var accountList = await _accountRepository.GetAllAsync();
            return _mapper.Map<List<AccountsDto>>(accountList);
        }
    }
}

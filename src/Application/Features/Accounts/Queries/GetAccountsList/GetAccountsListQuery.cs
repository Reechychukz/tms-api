using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Accounts.Queries.GetAccountsList
{
    public class GetAccountsListQuery : IRequest<List<AccountsVm>>
    {
        public Guid CustomerId { get; set; }

        public GetAccountsListQuery(Guid customerId)
        {
            CustomerId = CustomerId;
        }
    }

    public class GetAccountsListQueryHandler : IRequestHandler<GetAccountsListQuery, List<AccountsVm>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountsListQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<List<AccountsVm>> Handle(GetAccountsListQuery request, CancellationToken cancellationToken)
        {
            var accountList = await _accountRepository.GetAccountsByCustomerId(request.CustomerId);
            return _mapper.Map<List<AccountsVm>>(accountList);
        }
    }
}

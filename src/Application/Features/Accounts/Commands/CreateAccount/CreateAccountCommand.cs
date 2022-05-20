using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        //Parent Id
        public Guid CustomerId { get; set; }
        public EAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAccountCommandHandler> _logger;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<CreateAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _mapper.Map<Account>(request);
            var newAccount = await _accountRepository.AddAsync(account);

            _logger.LogInformation($"Tranaction {newAccount.Id} is successfully created");
            return newAccount.Id;
        }
    }
}

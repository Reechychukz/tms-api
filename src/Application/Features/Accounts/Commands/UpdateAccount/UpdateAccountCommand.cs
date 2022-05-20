using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public EAccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public double Balance { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(request.Id);
            if (accountToUpdate == null)
                throw new NotFoundException(nameof(Account), request.Id);

            _mapper.Map(request, accountToUpdate, typeof(UpdateAccountCommand), typeof(Account));

            await _accountRepository.UpdateAsync(accountToUpdate);
            return Unit.Value;
        }
    }
}

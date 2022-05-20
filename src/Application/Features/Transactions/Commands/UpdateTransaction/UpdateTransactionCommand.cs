using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Accounts.Commands.UpdateAccount;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : IRequest
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

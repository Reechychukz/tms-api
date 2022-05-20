using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelete = await _accountRepository.GetByIdAsync(request.Id);
            if (accountToDelete == null)
                throw new NotFoundException(nameof(Account), request.Id);

            await _accountRepository.DeleteAsync(accountToDelete);
            return Unit.Value;
        }
    }
}

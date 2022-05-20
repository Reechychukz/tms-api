using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionToDelete = await _transactionRepository.GetByIdAsync(request.Id);
            if (transactionToDelete == null)
                throw new NotFoundException(nameof(Transaction), request.Id);
            
            await _transactionRepository.DeleteAsync(transactionToDelete);
            return Unit.Value;
        }
    }
}

using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionToUpdate = await _transactionRepository.GetByIdAsync(request.Id);
            if (transactionToUpdate == null)
                throw new NotFoundException(nameof(Transaction), request.Id);

            _mapper.Map(request, transactionToUpdate, typeof(UpdateTransactionCommand), typeof(Transaction));

            await _transactionRepository.UpdateAsync(transactionToUpdate);
            return Unit.Value;
        }
    }
}

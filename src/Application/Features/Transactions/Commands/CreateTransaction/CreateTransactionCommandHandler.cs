using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Transactions.Commands.InitiateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTransactionCommandHandler> _logger;
        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper,
            ILogger<CreateTransactionCommandHandler> logger)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            var newTransaction = await _transactionRepository.AddAsync(transaction);

            _logger.LogInformation($"Tranaction {newTransaction.Id} is successfully created");
            return newTransaction.Id;
        }
    }
}

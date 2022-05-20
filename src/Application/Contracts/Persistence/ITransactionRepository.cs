using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsBySender(string sender);
    }
}

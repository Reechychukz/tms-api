using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByCustomerId(Guid userId);
    }
}

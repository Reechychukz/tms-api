using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersByFIrstName(string firstName);
    }
}

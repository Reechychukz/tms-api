using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(AppDbContext dbContext): base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetCustomersByFIrstName(string firstName)
        {
            var customerList = await _dbcontext.Customers
                                        .Where(t => t.FirstName == firstName)
                                        .ToListAsync();
            return customerList;
        }
    }
}

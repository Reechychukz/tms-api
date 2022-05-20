using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Account>> GetAccountsByCustomerId(Guid customerId)
        {
            var accountList = await _dbcontext.Accounts
                                        .Where(t => t.CustomerId == customerId)
                                        .ToListAsync();
            return accountList;
        }
    }
}

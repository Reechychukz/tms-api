using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {

        public TransactionRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsBySender(string sender)
        {
            var transactionList = await _dbcontext.Transactions
                .Where(t => t.FromAcct == sender)
                .ToListAsync();
            return transactionList;
        }
    }
}

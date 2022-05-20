using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext, ILogger<AppContextSeed> logger)
        {
            if (!appDbContext.Transactions.Any())
            {
                appDbContext.Transactions.AddRange(GetPreConfigureTransactions());
                await appDbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbCOntextName}", typeof(AppDbContext).Name);
            }
        }



        public static IEnumerable<Transaction> GetPreConfigureTransactions()
        {
            return new List<Transaction>
            {
                new Transaction(){Id = Guid.NewGuid(), Amount = 49.43, FromAcct = "12345678910", ToAcct = "12345678102", TransactionChannel = Domain.Enums.ETransactionChannel.INTERNETBANKING, TransactionType = Domain.Enums.ETransactionType.DEBIT }
            };
        }
    }
}

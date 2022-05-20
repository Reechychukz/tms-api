using Domain.Entities;
using Domain.Entities.Identities;
using Infrastructure.Data.DbContext.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}

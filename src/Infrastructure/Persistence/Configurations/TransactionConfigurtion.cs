using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class TransactionConfigurtion : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(x => x.FromAcct)
                .IsRequired();

            builder.Property(x => x.ToAcct)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();
        }
    }
}

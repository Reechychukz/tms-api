using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.DbContext.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.Customer.Id);

            builder.HasIndex(x => x.AccountNumber).IsUnique();

            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.AccountType).IsRequired();
        }
    }
}

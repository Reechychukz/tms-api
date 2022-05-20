using Application.Contracts.Persistence;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}

using Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;
using Infrastructure.Repository;

namespace Infrastructure.Configuration
{
    public static class InfrastructureIoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("Accounts"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}

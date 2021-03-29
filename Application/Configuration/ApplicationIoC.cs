using Application.Services;
using Domain.Services;
using Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class ApplicationIoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddInfrastructure();

            return services;
        }
    }
}

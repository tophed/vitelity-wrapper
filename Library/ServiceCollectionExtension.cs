using Microsoft.Extensions.DependencyInjection;
using Vitelity.Commands;

namespace Vitelity
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddVitelity(this IServiceCollection services)
        {
            services.AddTransient<IDIDInventoryCommands, DIDInventoryCommands>();
            services.AddTransient(typeof(DIDInventory));
            return services;
        }
    }
}
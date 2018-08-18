using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Vitelity.Api;
using Vitelity.Commands;
using Vitelity.Utility;

namespace Vitelity
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddVitelity(this IServiceCollection services, Credentials credentials)
        {
            services.TryAddSingleton<HttpClient>(new HttpClient());
            services.AddSingleton(credentials);
            services.AddSingleton(typeof(CommandUrlBuilder));
            services.AddSingleton(new ResponseDeserializer());
            services.AddTransient<IDIDInventoryCommands, DIDInventoryCommands>();
            services.AddTransient<IDIDOrderingCommands, DIDOrderingCommands>();
            services.AddTransient(typeof(DIDInventory));
            services.AddTransient(typeof(DIDOrdering));
            return services;
        }
    }
}
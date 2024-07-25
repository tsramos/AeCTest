using AecTest.Core.Contracts.Repository;
using AeCTest.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AeCTest.IOC
{
    public static class DependencyInjection
    {
        public static void InjectServices(this IServiceCollection service)
        {
            
        }

        public static void InjectRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}

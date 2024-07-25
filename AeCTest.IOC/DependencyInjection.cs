using AecTest.Core.Contracts.Repository;
using AecTest.Core.Contracts.Services;
using AecTest.Service;
using AeCTest.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AeCTest.IOC
{
    public static class DependencyInjection
    {
        public static void InjectServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAddressService, AddressService>();
        }

        public static void InjectRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}

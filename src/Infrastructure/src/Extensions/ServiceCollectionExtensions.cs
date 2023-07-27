using DeviceManagement.Domain.Contracts;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

namespace DeviceManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeviceManagementRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITransponderRepository, ClassicTransponderRepository>();
            services.AddScoped<ITransponderRepository, ModernTransponderRepository>();
            services.AddScoped<IVehicleRepository, DummyVehicleRepository>();

            services.AddScoped<ITransponderRepositoryFactory, TransponderRepositoryFactory>();

            return services;
        }
    }
}
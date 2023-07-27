using DeviceManagement.Infrastructure.Extensions;
using DeviceManagement.Services.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManagement.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeviceManagementServices(this IServiceCollection services)
        {
            services.AddDeviceManagementRepositories();

            services.AddScoped<ITransponderService, TransponderService>();
            services.AddScoped<IVehicleService, VehicleService>();

            return services;
        }

        public static IApplicationBuilder UseDeviceManagementServices(this IApplicationBuilder app)
        {
            app.UseMiddleware<DeviceManagementMiddleware>();

            return app;
        }
    }
}
using Microsoft.AspNetCore.Http;

namespace DeviceManagement.Services.Middleware
{
    public class DeviceManagementMiddleware
    {
        private readonly RequestDelegate _next;

        public DeviceManagementMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITransponderService transponderService, IVehicleService vehicleService)
        {
            vehicleService.VehicleCreated += (sender, args) => transponderService.OnVehicleCreated(args);

            await _next(context);
        }
    }
}
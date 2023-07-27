using DeviceManagement.Domain.Contracts;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Events;
using DeviceManagement.Domain.Handlers;
using Microsoft.Extensions.Logging;

namespace DeviceManagement.Services
{
    public interface IVehicleService
    {
        event VehicleCreatedEventHandler VehicleCreated;
        Task<Vehicle> Create(Vehicle vehicle);
    }

    public class VehicleService : IVehicleService
    {
        private readonly ILogger<VehicleService> _logger;
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(ILogger<VehicleService> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        public event VehicleCreatedEventHandler VehicleCreated = default!;

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            _logger.LogInformation($"{nameof(VehicleService)}: raising {nameof(VehicleCreated)} event");

            VehicleCreated?.Invoke(this, new VehicleEventArgs { Vehicle = await _vehicleRepository.Create(vehicle) });

            return vehicle;
        }
    }
}
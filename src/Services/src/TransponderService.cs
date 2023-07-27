using DeviceManagement.Domain.Entities;
using DeviceManagement.Domain.Events;
using DeviceManagement.Infrastructure;
using Microsoft.Extensions.Logging;

namespace DeviceManagement.Services
{
    public interface ITransponderService
    {
        Task<Transponder> Create(Vehicle vehicle);
        Task OnVehicleCreated(VehicleEventArgs vehicleEventArgs);
    }

    public class TransponderService : ITransponderService
    {
        private readonly ILogger<TransponderService> _logger;
        private readonly ITransponderRepositoryFactory _transponderRepositoryFactory;

        public TransponderService(ILogger<TransponderService> logger, ITransponderRepositoryFactory transponderRepositoryFactory)
        {
            _logger = logger;
            _transponderRepositoryFactory = transponderRepositoryFactory;
        }

        public async Task<Transponder> Create(Vehicle vehicle)
        {
            var repo = _transponderRepositoryFactory.GetTransponderRepsitory(int.Parse(vehicle.Year));

            var transponder = await repo.Create(vehicle);

            _logger.LogInformation($"Created Transponder {transponder.Id} for vehicle {vehicle.Id}");

            return transponder;
        }

        public async Task OnVehicleCreated(VehicleEventArgs vehicleEventArgs)
        {
            _logger.LogInformation($"{nameof(TransponderService)}: handling VehicleCreated event");

            var vehicle = vehicleEventArgs.Vehicle;

            await Create(vehicle);
        }
    }
}
using DeviceManagement.Domain.Contracts;
using DeviceManagement.Domain.Entities;

namespace DeviceManagement.Infrastructure.Repositories
{
    public class DummyVehicleRepository : IVehicleRepository
    {
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            // simulating creation of new vehicle
            vehicle.Id = new Random().NextInt64();

            return await Task.FromResult(vehicle);
        }
    }
}
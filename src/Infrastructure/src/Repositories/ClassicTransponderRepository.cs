using DeviceManagement.Domain.Contracts;
using DeviceManagement.Domain.Entities;

namespace DeviceManagement.Infrastructure.Repositories
{
    public class ClassicTransponderRepository : ITransponderRepository
    {
        public async Task<Transponder> Create(Vehicle vehicle)
        {
            // simulating creation of new transponder in classic storage provider
            var transponder = Transponder.Create(vehicle);
            transponder.Id = new Random().NextInt64();
            return await Task.FromResult(transponder);
        }
    }
}
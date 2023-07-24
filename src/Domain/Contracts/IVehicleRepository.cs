using DeviceManagement.Domain.Entities;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Contracts
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Create(Vehicle vehicle);
    }
}
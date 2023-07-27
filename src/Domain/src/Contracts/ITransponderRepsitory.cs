using DeviceManagement.Domain.Entities;
using System.Threading.Tasks;

namespace DeviceManagement.Domain.Contracts
{
    public interface ITransponderRepository
    {
        Task<Transponder> Create(Vehicle vehicle);
    }
}
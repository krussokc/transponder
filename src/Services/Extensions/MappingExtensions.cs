using DeviceManagement.Domain.Entities;
using DeviceManagement.Services.Dtos;

namespace DeviceManagement.Services.Extensions
{
    public static class MappingExtensions
    {
        public static TransponderDto ToDto(this Transponder transponder)
        {
            return new TransponderDto(
                transponder.VehicleId
            );
        }

        public static VehicleDto ToDto(this Vehicle vehicle)
        {
            return new VehicleDto(
                vehicle.Make,
                vehicle.Model,
                vehicle.Year
            );
        }
    }
}
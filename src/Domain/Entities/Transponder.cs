using Company.Domain;

namespace DeviceManagement.Domain.Entities
{
    public class Transponder : Entity
    {
        public Transponder() { }

        private Transponder(Vehicle vehicle)
        {
            UpdateVehile(vehicle);
        }

        public static Transponder Create(Vehicle vehicle)
        {
            return new Transponder(vehicle);
        }

        public void UpdateVehile(Vehicle vehicle)
        {
            VehicleId = vehicle.Id;
            Vehicle = vehicle;
        }

        public long VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = default!;
    }
}
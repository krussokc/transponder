using DeviceManagement.Domain.Events;

namespace DeviceManagement.Domain.Handlers
{
    public delegate void VehicleCreatedEventHandler(object source, VehicleEventArgs args);
}

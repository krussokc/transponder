using DeviceManagement.Domain.Entities;
using System;

namespace DeviceManagement.Domain.Events
{
    public class VehicleEventArgs : EventArgs
    {
        public Vehicle Vehicle { get; set; }
    }
}
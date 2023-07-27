using Company.Data.Configuration;
using DeviceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceManagement.Data.Configuration
{
    public class VehicleConfig : BaseConfig<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.ToTable("Vehicles");
        }
    }
}
using Company.Data.Configuration;
using DeviceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceManagement.Data.Configuration
{
    public class TransponderConfig : BaseConfig<Transponder>
    {
        public override void Configure(EntityTypeBuilder<Transponder> builder)
        {
            base.Configure(builder);

            builder.ToTable("Transponders");
        }
    }
}

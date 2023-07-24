using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.Data
{
    public class DeviceManagementDbContext : BaseDbContext
    {
        public DeviceManagementDbContext(DbContextOptions<DeviceManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DeviceManagement");

            base.OnModelCreating(modelBuilder);
        }
    }
}
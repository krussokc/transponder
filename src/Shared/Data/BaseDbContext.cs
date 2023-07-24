using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = Assembly.GetAssembly(GetType());

            Console.WriteLine($"{assembly} context");

            if (assembly != null)
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            else
                throw new NullReferenceException($"The assembly for {GetType().FullName} was null when attempting to apply configurations.");
        }
    }
}
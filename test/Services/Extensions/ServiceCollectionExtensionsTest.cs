using DeviceManagement.Domain.Contracts;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Repositories;
using DeviceManagement.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManagement.Services.Tests.Extensions
{
    public class ServiceCollectionExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDeviceManagementServices_Should_Add_Required_Services()
        {
            var services = new ServiceCollection();

            var provider = services.AddDeviceManagementServices();

            Assert.That(provider.Count, Is.GreaterThan(0));

            var classicTransponderRepository = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(ITransponderRepository)) &&
                x.ImplementationType.Name.Equals(nameof(ClassicTransponderRepository)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            var modernTransponderRepository = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(ITransponderRepository)) &&
                x.ImplementationType.Name.Equals(nameof(ModernTransponderRepository)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            var dummyVehicleRepository = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(IVehicleRepository)) &&
                x.ImplementationType.Name.Equals(nameof(DummyVehicleRepository)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            var transponderRepositoryFactory = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(ITransponderRepositoryFactory)) &&
                x.ImplementationType.Name.Equals(nameof(TransponderRepositoryFactory)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            var transponderService = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(ITransponderService)) &&
                x.ImplementationType.Name.Equals(nameof(TransponderService)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            var vehicleService = provider.FirstOrDefault(x =>
                x.ServiceType.Name.Equals(nameof(IVehicleService)) &&
                x.ImplementationType.Name.Equals(nameof(VehicleService)) &&
                x.Lifetime == ServiceLifetime.Scoped);

            Assert.That(classicTransponderRepository, Is.Not.Null);
            Assert.That(modernTransponderRepository, Is.Not.Null);
            Assert.That(dummyVehicleRepository, Is.Not.Null);
            Assert.That(transponderRepositoryFactory, Is.Not.Null);
            Assert.That(transponderService, Is.Not.Null);
            Assert.That(vehicleService, Is.Not.Null);
        }

        [Test]
        public void UseDeviceManagmentServices_Should_Add_Required_Middleware()
        {
        }
    }
}

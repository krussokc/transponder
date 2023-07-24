using Bogus;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Services.Extensions;

namespace DeviceManagement.Services.Tests.Extensions
{
    public class MappingExtensionsTest
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void Transonponder_Domain_ToDto_Extension_Should_Map_Properly()
        {
            var vehicle = new Faker<Vehicle>().Generate();
            var transponder = new Faker<Transponder>().Generate();

            transponder.UpdateVehile(vehicle);

            var transponderDto = transponder.ToDto();

            Assert.That(transponderDto.VehicleId, Is.EqualTo(transponder.VehicleId));
        }

        [Test]
        public void Vehicle_Domain_ToDto_Extension_Should_Map_Properly()
        {
            var vehile = new Faker<Vehicle>().Generate();

            var vehicleDto = vehile.ToDto();

            Assert.That(vehicleDto.Make, Is.EqualTo(vehile.Make));
            Assert.That(vehicleDto.Model, Is.EqualTo(vehile.Model));
            Assert.That(vehicleDto.Year, Is.EqualTo(vehile.Year.ToString()));
        }
    }
}
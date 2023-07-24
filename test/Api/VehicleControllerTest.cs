using DeviceManagement.Api.Controllers;
using DeviceManagement.Domain.Entities;
using DeviceManagement.Services;
using DeviceManagement.Services.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DeviceManagement.Api.Tests
{
    public class VehicleControllerTest
    {
        private WebApplicationFactory<Program> _application;
        private Mock<ILogger<VehicleController>> _logger;
        private Mock<IVehicleService> _vehicleService;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<VehicleController>>();
            _vehicleService = new Mock<IVehicleService>();

            var application = new WebApplicationFactory<Program>();
            _application = application.WithWebHostBuilder(x => x.ConfigureTestServices(services =>
            {
                services.AddScoped((serviceProvider) => _vehicleService.Object);
            }));
        }

        [Test]
        public async Task Posting_Valid_Dto_Should_Result_In_Successful_Status()
        {
            var client = _application.CreateClient();
            var url = "/vehicles";

            var vehicleDto = new VehicleDto("Jeep", "Wrangler", "2017");
            var vehicle = Vehicle.Create(vehicleDto.Make, vehicleDto.Model, vehicleDto.Year);

            _vehicleService.Setup(x => x.Create(It.IsAny<Vehicle>())).ReturnsAsync(vehicle).Verifiable();

            var json = JsonConvert.SerializeObject(vehicleDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task Posting_InValid_Year_Should_Result_In_BadRequest_Status()
        {
            var client = _application.CreateClient();
            var url = "/vehicles";

            var vehicleDto = new VehicleDto("Jeep", "Wrangler", "Rubicon");

            var json = JsonConvert.SerializeObject(vehicleDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            Assert.That(response.StatusCode == HttpStatusCode.BadRequest, Is.True);
        }

        [Test]
        public async Task VehicleController_CreateVehicle_Should_Call_VehicleService_When_Request_Is_Valid()
        {
            var vehicleController = new VehicleController(_logger.Object, _vehicleService.Object);

            var vehicleDto = new VehicleDto("Jeep", "Wrangler", "2017");
            var vehicle = Vehicle.Create(vehicleDto.Make, vehicleDto.Model, vehicleDto.Year);

            _vehicleService.Setup(x => x.Create(It.IsAny<Vehicle>())).ReturnsAsync(vehicle).Verifiable();

            var response = await vehicleController.CreateVehicle(vehicleDto);

            _vehicleService.Verify();
        }
    }
}
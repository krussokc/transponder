using DeviceManagement.Domain.Entities;
using DeviceManagement.Services;
using DeviceManagement.Services.Dtos;
using DeviceManagement.Services.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.Api.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateVehicle(VehicleDto vehicleDto)
        {
            int.TryParse(vehicleDto.Year, out var year);

            if (year == 0)
            {
                return BadRequest("Year is not valid");
            }

            var vehicle = await _vehicleService.Create(Vehicle.Create(vehicleDto.Make, vehicleDto.Model, vehicleDto.Year));

            return Ok(vehicle.ToDto());
        }
    }
}
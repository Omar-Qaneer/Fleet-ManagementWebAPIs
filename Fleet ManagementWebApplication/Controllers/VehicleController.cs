using Fleet_ManagementWebApplication.Models;
using Fleet_ManagementWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_ManagementWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;


        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _vehicleService.GetVehiclesList();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var result = await _vehicleService.GetVehicle(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] Vehicles vehicle)
        {
            var result = await _vehicleService.CreateVehicle(vehicle);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] Vehicles vehicle)
        {
            var result = await _vehicleService.UpdateVehicle(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicle(id);

            return Ok(result);
        }
    }
}


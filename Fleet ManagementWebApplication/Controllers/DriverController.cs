using Fleet_ManagementWebApplication.Models;
using Fleet_ManagementWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_ManagementWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriver _driverService;


        public DriverController(IDriver driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _driverService.GetDriversList();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var result = await _driverService.GetDriver(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] Driver driver)
        {
            var result = await _driverService.CreateDriver(driver);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] Driver driver)
        {
            var result = await _driverService.UpdateDriver(driver);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var result = await _driverService.DeleteDriver(id);

            return Ok(result);
        }
    }
}


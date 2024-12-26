using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenSim.RESTful.API.Services;

namespace OpenSim.RESTful.API.Controllers
{
    [ApiController]
    [Route("api/restful/simulator")]
    public class SimulatorController : ControllerBase
    {
        private readonly ISimulatorService _simulatorService;

        public SimulatorController(ISimulatorService simulatorService)
        {
            _simulatorService = simulatorService;
        }

        [HttpPost("regions/{regionName}/shutdown")]
        public async Task<IActionResult> ShutdownRegion(string regionName)
        {
            var result = await _simulatorService.ShutdownRegionAsync(regionName);
            return Ok(new { result });
        }

        [HttpGet("regions")]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await _simulatorService.GetAllSimulatorRegionsAsync();
            return Ok(new { regions });
        }
    }
}

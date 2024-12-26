using System.Threading.Tasks;

using OpenSim.Framework;
using OpenSim.RESTful.API.Services;
using OpenSim.Services.Interfaces;

namespace OpenSim.RESTful.API.Controllers
{
    public class SimulatorController
    {
        private readonly ISimulatorService _simulatorService;

        public SimulatorController(ISimulatorService simulatorService)
        {
            _simulatorService = simulatorService;
        }

        public async Task<string> ShutdownRegion(string regionName)
        {
            var result = await _simulatorService.ShutdownRegionAsync(regionName);
            return result;
        }

        public async Task<string> GetRegions()
        {
            var regions = await _simulatorService.GetAllSimulatorRegionsAsync();
            return regions.ToString();
        }
    }
}


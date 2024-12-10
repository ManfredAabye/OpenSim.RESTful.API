[ApiController]
[Route("api/restful/simulator")]
public class RESTfulAPISimulatorController : ControllerBase
{
    private readonly IRESTfulAPISimulatorService _simulatorService;

    public RESTfulAPISimulatorController(IRESTfulAPISimulatorService simulatorService)
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

[ApiController]
[Route("api/simulator")]
public class SimulatorController : ControllerBase
{
    private readonly ISimulatorService _simulatorService;

    public SimulatorController(ISimulatorService simulatorService)
    {
        _simulatorService = simulatorService;
    }

    [HttpPost("region/{regionName}/shutdown")]
    public async Task<IActionResult> ShutdownRegion(string regionName)
    {
        var result = await _simulatorService.ShutdownRegionAsync(regionName);
        return Ok(new { result });
    }
}
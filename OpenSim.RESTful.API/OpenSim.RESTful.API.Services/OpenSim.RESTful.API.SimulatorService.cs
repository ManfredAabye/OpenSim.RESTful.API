public interface IRESTfulAPISimulatorService
{
    Task<string> ShutdownRegionAsync(string regionName);
    Task<string> GetAllSimulatorRegionsAsync();
}

public class RESTfulAPISimulatorService : IRESTfulAPISimulatorService
{
    private readonly IOpenSimService _openSimService;

    public RESTfulAPISimulatorService(IOpenSimService openSimService)
    {
        _openSimService = openSimService;
    }

    public async Task<string> ShutdownRegionAsync(string regionName)
    {
        return await _openSimService.ExecuteCommandAsync($"shutdown region \"{regionName}\"");
    }

    public async Task<string> GetAllSimulatorRegionsAsync()
    {
        return await _openSimService.ExecuteCommandAsync("show regions");
    }
}

public class SimulatorService : ISimulatorService
{
    private readonly IOpenSimService _openSimService;

    public SimulatorService(IOpenSimService openSimService)
    {
        _openSimService = openSimService;
    }

    public async Task<string> ShutdownRegionAsync(string regionName)
    {
        var command = CommandParser.BuildRegionShowCommand(regionName);
        return await _openSimService.ExecuteCommandAsync(command);
    }
}
public interface IRESTfulAPIGeneralService
{
    Task<string> GetServerUptimeAsync();
    Task<string> GetAllUsersAsync();
}

public class RESTfulAPIGeneralService : IRESTfulAPIGeneralService
{
    private readonly IOpenSimService _openSimService;

    public RESTfulAPIGeneralService(IOpenSimService openSimService)
    {
        _openSimService = openSimService;
    }

    public async Task<string> GetServerUptimeAsync()
    {
        return await _openSimService.ExecuteCommandAsync("show uptime");
    }

    public async Task<string> GetAllUsersAsync()
    {
        return await _openSimService.ExecuteCommandAsync("show users");
    }
}
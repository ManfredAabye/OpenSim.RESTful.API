public interface IRESTfulAPIRobustService
{
    Task<string> GetAllRegionsAsync();
    Task<string> GetRegionDetailsAsync(string regionName);
    Task<string> CreateUserAsync(string firstName, string lastName, string password, string email);
    Task<string> ResetUserPasswordAsync(string userId, string newPassword);
}

public class RESTfulAPIRobustService : IRESTfulAPIRobustService
{
    private readonly IOpenSimService _openSimService;

    public RESTfulAPIRobustService(IOpenSimService openSimService)
    {
        _openSimService = openSimService;
    }

    public async Task<string> GetAllRegionsAsync()
    {
        return await _openSimService.ExecuteCommandAsync("show regions");
    }

    public async Task<string> GetRegionDetailsAsync(string regionName)
    {
        return await _openSimService.ExecuteCommandAsync($"show region \"{regionName}\"");
    }

    public async Task<string> CreateUserAsync(string firstName, string lastName, string password, string email)
    {
        return await _openSimService.ExecuteCommandAsync($"create user {firstName} {lastName} {password} {email}");
    }

    public async Task<string> ResetUserPasswordAsync(string userId, string newPassword)
    {
        return await _openSimService.ExecuteCommandAsync($"reset user password {userId} {newPassword}");
    }
}
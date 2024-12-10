[ApiController]
[Route("api/restful/robust")]
public class RESTfulAPIRobustController : ControllerBase
{
    private readonly IRESTfulAPIRobustService _robustService;

    public RESTfulAPIRobustController(IRESTfulAPIRobustService robustService)
    {
        _robustService = robustService;
    }

    [HttpGet("regions")]
    public async Task<IActionResult> GetRegions()
    {
        var regions = await _robustService.GetAllRegionsAsync();
        return Ok(new { regions });
    }

    [HttpGet("region/{regionName}")]
    public async Task<IActionResult> GetRegion(string regionName)
    {
        var regionDetails = await _robustService.GetRegionDetailsAsync(regionName);
        return Ok(new { regionDetails });
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var result = await _robustService.CreateUserAsync(user.FirstName, user.LastName, user.Password, user.Email);
        return Ok(new { result });
    }

    [HttpPut("users/{userId}/password")]
    public async Task<IActionResult> ResetPassword(string userId, [FromBody] string newPassword)
    {
        var result = await _robustService.ResetUserPasswordAsync(userId, newPassword);
        return Ok(new { result });
    }
}
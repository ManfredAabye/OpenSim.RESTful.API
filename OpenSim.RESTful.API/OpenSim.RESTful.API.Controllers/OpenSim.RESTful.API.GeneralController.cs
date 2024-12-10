[ApiController]
[Route("api/restful/general")]
public class RESTfulAPIGeneralController : ControllerBase
{
    private readonly IRESTfulAPIGeneralService _generalService;

    public RESTfulAPIGeneralController(IRESTfulAPIGeneralService generalService)
    {
        _generalService = generalService;
    }

    [HttpGet("uptime")]
    public async Task<IActionResult> GetUptime()
    {
        var uptime = await _generalService.GetServerUptimeAsync();
        return Ok(new { uptime });
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _generalService.GetAllUsersAsync();
        return Ok(new { users });
    }
}
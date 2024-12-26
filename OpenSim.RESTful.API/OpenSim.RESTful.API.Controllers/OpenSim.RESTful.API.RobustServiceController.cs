using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenSim.RESTful.API.Models;
using OpenSim.RESTful.API.Services;

namespace OpenSim.RESTful.API.Controllers
{
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

        [HttpPost("change-region")]
        public IActionResult ChangeRegion(string regionName)
        {
            var result = _robustService.ChangeRegion(regionName);
            return Ok(result);
        }

        [HttpPost("force-update")]
        public IActionResult ForceUpdate()
        {
            var result = _robustService.ForceUpdate();
            return Ok(result);
        }

        [HttpPost("save-xml")]
        public IActionResult SaveXml(string fileName)
        {
            var result = _robustService.SaveXml(fileName);
            return Ok(result);
        }

        [HttpPost("save-xml2")]
        public IActionResult SaveXml2(string fileName)
        {
            var result = _robustService.SaveXml2(fileName);
            return Ok(result);
        }

        [HttpPost("load-xml")]
        public IActionResult LoadXml(string fileName, bool newUID = false, Vector3? position = null)
        {
            var result = _robustService.LoadXml(fileName, newUID, position);
            return Ok(result);
        }

        [HttpPost("load-xml2")]
        public IActionResult LoadXml2(string fileName)
        {
            var result = _robustService.LoadXml2(fileName);
            return Ok(result);
        }

        [HttpPost("save-prims-xml2")]
        public IActionResult SavePrimsXml2(string primName, string fileName)
        {
            var result = _robustService.SavePrimsXml2(primName, fileName);
            return Ok(result);
        }

        [HttpPost("load-oar")]
        public IActionResult LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null)
        {
            var result = _robustService.LoadOar(oarPath, merge, skipAssets, defaultUser, options);
            return Ok(result);
        }

        [HttpPost("save-oar")]
        public IActionResult SaveOar(string oarPath, string options = null)
        {
            var result = _robustService.SaveOar(oarPath, options);
            return Ok(result);
        }

        [HttpPost("edit-scale")]
        public IActionResult EditScale(string primName, float x, float y, float z)
        {
            var result = _robustService.EditScale(primName, x, y, z);
            return Ok(result);
        }

        [HttpPost("rotate-scene")]
        public IActionResult RotateScene(float degrees, float centerX = 128, float centerY = 128)
        {
            var result = _robustService.RotateScene(degrees, centerX, centerY);
            return Ok(result);
        }

        [HttpPost("scale-scene")]
        public IActionResult ScaleScene(float factor)
        {
            var result = _robustService.ScaleScene(factor);
            return Ok(result);
        }

        [HttpPost("translate-scene")]
        public IActionResult TranslateScene(float xOffset, float yOffset, float zOffset)
        {
            var result = _robustService.TranslateScene(xOffset, yOffset, zOffset);
            return Ok(result);
        }

        [HttpPost("kick-user")]
        public IActionResult KickUser(string firstName, string lastName, bool force = false, string message = null)
        {
            var result = _robustService.KickUser(firstName, lastName, force, message);
            return Ok(result);
        }

        [HttpGet("show-users")]
        public IActionResult ShowUsers(bool full = false)
        {
            var result = _robustService.ShowUsers(full);
            return Ok(result);
        }

        [HttpGet("show-connections")]
        public IActionResult ShowConnections()
        {
            var result = _robustService.ShowConnections();
            return Ok(result);
        }

        [HttpGet("show-circuits")]
        public IActionResult ShowCircuits()
        {
            var result = _robustService.ShowCircuits();
            return Ok(result);
        }

        [HttpGet("show-pending-objects")]
        public IActionResult ShowPendingObjects()
        {
            var result = _robustService.ShowPendingObjects();
            return Ok(result);
        }

        [HttpGet("show-modules")]
        public IActionResult ShowModules()
        {
            var result = _robustService.ShowModules();
            return Ok(result);
        }

        [HttpGet("show-regions")]
        public IActionResult ShowRegions()
        {
            var result = _robustService.ShowRegions();
            return Ok(result);
        }

        [HttpGet("show-ratings")]
        public IActionResult ShowRatings()
        {
            var result = _robustService.ShowRatings();
            return Ok(result);
        }

        [HttpPost("backup")]
        public IActionResult Backup()
        {
            var result = _robustService.Backup();
            return Ok(result);
        }

        [HttpPost("create-region")]
        public IActionResult CreateRegion(string regionName, string regionFile)
        {
            var result = _robustService.CreateRegion(regionName, regionFile);
            return Ok(result);
        }

        [HttpPost("restart")]
        public IActionResult Restart()
        {
            var result = _robustService.Restart();
            return Ok(result);
        }

        [HttpPost("command-script")]
        public IActionResult CommandScript(string script)
        {
            var result = _robustService.CommandScript(script);
            return Ok(result);
        }

        [HttpPost("remove-region")]
        public IActionResult RemoveRegion(string regionName)
        {
            var result = _robustService.RemoveRegion(regionName);
            return Ok(result);
        }

        [HttpPost("delete-region")]
        public IActionResult DeleteRegion(string regionName)
        {
            var result = _robustService.DeleteRegion(regionName);
            return Ok(result);
        }

        [HttpPost("create-estate")]
        public IActionResult CreateEstate(string ownerUUID, string estateName)
        {
            var result = _robustService.CreateEstate(ownerUUID, estateName);
            return Ok(result);
        }

        [HttpPost("set-estate-owner")]
        public IActionResult SetEstateOwner(int estateId, string ownerUUID)
        {
            var result = _robustService.SetEstateOwner(estateId, ownerUUID);
            return Ok(result);
        }

        [HttpPost("set-estate-name")]
        public IActionResult SetEstateName(int estateId, string newName)
        {
            var result = _robustService.SetEstateName(estateId, newName);
            return Ok(result);
        }

        [HttpPost("estate-link-region")]
        public IActionResult EstateLinkRegion(int estateId, int regionId)
        {
            var result = _robustService.EstateLinkRegion(estateId, regionId);
            return Ok(result);
        }
    }
}

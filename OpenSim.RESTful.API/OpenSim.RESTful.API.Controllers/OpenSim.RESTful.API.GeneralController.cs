using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenSim.RESTful.API.Services;

namespace OpenSim.RESTful.API.Controllers
{
    [ApiController]
    [Route("api/restful/general")]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralService _generalService;

        public GeneralController(IGeneralService generalService)
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

        [HttpPost("force-update")]
        public IActionResult ForceUpdate()
        {
            var result = _generalService.ForceUpdate();
            return Ok(result);
        }

        [HttpPost("change-region")]
        public IActionResult ChangeRegion(string regionName)
        {
            var result = _generalService.ChangeRegion(regionName);
            return Ok(result);
        }

        [HttpPost("save-xml")]
        public IActionResult SaveXml(string fileName)
        {
            var result = _generalService.SaveXml(fileName);
            return Ok(result);
        }

        [HttpPost("save-xml2")]
        public IActionResult SaveXml2(string fileName)
        {
            var result = _generalService.SaveXml2(fileName);
            return Ok(result);
        }

        [HttpPost("load-xml")]
        public IActionResult LoadXml(string fileName, bool newUID = false, Vector3? position = null)
        {
            var result = _generalService.LoadXml(fileName, newUID, position);
            return Ok(result);
        }

        [HttpPost("load-xml2")]
        public IActionResult LoadXml2(string fileName)
        {
            var result = _generalService.LoadXml2(fileName);
            return Ok(result);
        }

        [HttpPost("save-prims-xml2")]
        public IActionResult SavePrimsXml2(string primName, string fileName)
        {
            var result = _generalService.SavePrimsXml2(primName, fileName);
            return Ok(result);
        }

        [HttpPost("load-oar")]
        public IActionResult LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null)
        {
            var result = _generalService.LoadOar(oarPath, merge, skipAssets, defaultUser, options);
            return Ok(result);
        }

        [HttpPost("save-oar")]
        public IActionResult SaveOar(string oarPath, string options = null)
        {
            var result = _generalService.SaveOar(oarPath, options);
            return Ok(result);
        }

        [HttpPost("edit-scale")]
        public IActionResult EditScale(string primName, float x, float y, float z)
        {
            var result = _generalService.EditScale(primName, x, y, z);
            return Ok(result);
        }

        [HttpPost("rotate-scene")]
        public IActionResult RotateScene(float degrees, float centerX = 128, float centerY = 128)
        {
            var result = _generalService.RotateScene(degrees, centerX, centerY);
            return Ok(result);
        }

        [HttpPost("scale-scene")]
        public IActionResult ScaleScene(float factor)
        {
            var result = _generalService.ScaleScene(factor);
            return Ok(result);
        }

        [HttpPost("translate-scene")]
        public IActionResult TranslateScene(float xOffset, float yOffset, float zOffset)
        {
            var result = _generalService.TranslateScene(xOffset, yOffset, zOffset);
            return Ok(result);
        }

        [HttpPost("kick-user")]
        public IActionResult KickUser(string firstName, string lastName, bool force = false, string message = null)
        {
            var result = _generalService.KickUser(firstName, lastName, force, message);
            return Ok(result);
        }

        [HttpGet("show-users")]
        public IActionResult ShowUsers(bool full = false)
        {
            var result = _generalService.ShowUsers(full);
            return Ok(result);
        }

        [HttpGet("show-connections")]
        public IActionResult ShowConnections()
        {
            var result = _generalService.ShowConnections();
            return Ok(result);
        }

        [HttpGet("show-circuits")]
        public IActionResult ShowCircuits()
        {
            var result = _generalService.ShowCircuits();
            return Ok(result);
        }

        [HttpGet("show-pending-objects")]
        public IActionResult ShowPendingObjects()
        {
            var result = _generalService.ShowPendingObjects();
            return Ok(result);
        }

        [HttpGet("show-modules")]
        public IActionResult ShowModules()
        {
            var result = _generalService.ShowModules();
            return Ok(result);
        }

        [HttpGet("show-regions")]
        public IActionResult ShowRegions()
        {
            var result = _generalService.ShowRegions();
            return Ok(result);
        }

        [HttpGet("show-ratings")]
        public IActionResult ShowRatings()
        {
            var result = _generalService.ShowRatings();
            return Ok(result);
        }

        [HttpPost("backup")]
        public IActionResult Backup()
        {
            var result = _generalService.Backup();
            return Ok(result);
        }

        [HttpPost("create-region")]
        public IActionResult CreateRegion(string regionName, string regionFile)
        {
            var result = _generalService.CreateRegion(regionName, regionFile);
            return Ok(result);
        }

        [HttpPost("restart")]
        public IActionResult Restart()
        {
            var result = _generalService.Restart();
            return Ok(result);
        }

        [HttpPost("command-script")]
        public IActionResult CommandScript(string script)
        {
            var result = _generalService.CommandScript(script);
            return Ok(result);
        }

        [HttpPost("remove-region")]
        public IActionResult RemoveRegion(string regionName)
        {
            var result = _generalService.RemoveRegion(regionName);
            return Ok(result);
        }

        [HttpPost("delete-region")]
        public IActionResult DeleteRegion(string regionName)
        {
            var result = _generalService.DeleteRegion(regionName);
            return Ok(result);
        }

        [HttpPost("create-estate")]
        public IActionResult CreateEstate(string ownerUUID, string estateName)
        {
            var result = _generalService.CreateEstate(ownerUUID, estateName);
            return Ok(result);
        }

        [HttpPost("set-estate-owner")]
        public IActionResult SetEstateOwner(int estateId, string ownerUUID)
        {
            var result = _generalService.SetEstateOwner(estateId, ownerUUID);
            return Ok(result);
        }

        [HttpPost("set-estate-name")]
        public IActionResult SetEstateName(int estateId, string newName)
        {
            var result = _generalService.SetEstateName(estateId, newName);
            return Ok(result);
        }

        [HttpPost("estate-link-region")]
        public IActionResult EstateLinkRegion(int estateId, int regionId)
        {
            var result = _generalService.EstateLinkRegion(estateId, regionId);
            return Ok(result);
        }
    }
}

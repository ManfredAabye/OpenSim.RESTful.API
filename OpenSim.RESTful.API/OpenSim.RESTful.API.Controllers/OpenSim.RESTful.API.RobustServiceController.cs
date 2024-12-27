using System.Collections.Generic;
using System.Threading.Tasks;

using OpenMetaverse;

using OpenSim.Framework;
using OpenSim.RESTful.API.Models;
using OpenSim.RESTful.API.Services;

namespace OpenSim.RESTful.API.Controllers
{
    public class RobustServiceController
    {
        private readonly IRobustService _robustService;

        public RobustServiceController(IRobustService robustService)
        {
            _robustService = robustService;
        }

        public async Task<IEnumerable<RegionInfo>> GetRegions()
        {
            var regions = await _robustService.GetAllRegionsAsync();
            return regions;
        }

        public async Task<RegionInfo> GetRegion(string regionName)
        {
            var regionDetails = await _robustService.GetRegionDetailsAsync(regionName);
            return regionDetails;
        }

        public async Task<string> CreateUser(User user)
        {
            var result = await _robustService.CreateUserAsync(user.FirstName, user.LastName, user.Password, user.Email);
            return result;
        }

        public async Task<string> ResetPassword(string userId, string newPassword)
        {
            var result = await _robustService.ResetUserPasswordAsync(userId, newPassword);
            return result;
        }

        public string ChangeRegion(string regionName)
        {
            var result = _robustService.ChangeRegion(regionName);
            return result;
        }

        public string ForceUpdate()
        {
            var result = _robustService.ForceUpdate();
            return result;
        }

        public string SaveXml(string fileName)
        {
            var result = _robustService.SaveXml(fileName);
            return result;
        }

        public string SaveXml2(string fileName)
        {
            var result = _robustService.SaveXml2(fileName);
            return result;
        }

        public string LoadXml(string fileName, bool newUID = false, OpenMetaverse.Vector3? position = null)
        {
            var result = _robustService.LoadXml(fileName, newUID, position);
            return result;
        }

        public string LoadXml2(string fileName)
        {
            var result = _robustService.LoadXml2(fileName);
            return result;
        }

        public string SavePrimsXml2(string primName, string fileName)
        {
            var result = _robustService.SavePrimsXml2(primName, fileName);
            return result;
        }

        public string LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null)
        {
            var result = _robustService.LoadOar(oarPath, merge, skipAssets, defaultUser, options);
            return result;
        }

        public string SaveOar(string oarPath, string options = null)
        {
            var result = _robustService.SaveOar(oarPath, options);
            return result;
        }

        public string EditScale(string primName, float x, float y, float z)
        {
            var result = _robustService.EditScale(primName, x, y, z);
            return result;
        }

        public string RotateScene(float degrees, float centerX = 128, float centerY = 128)
        {
            var result = _robustService.RotateScene(degrees, centerX, centerY);
            return result;
        }

        public string ScaleScene(float factor)
        {
            var result = _robustService.ScaleScene(factor);
            return result;
        }

        public string TranslateScene(float xOffset, float yOffset, float zOffset)
        {
            var result = _robustService.TranslateScene(xOffset, yOffset, zOffset);
            return result;
        }

        public string KickUser(string firstName, string lastName, bool force = false, string message = null)
        {
            var result = _robustService.KickUser(firstName, lastName, force, message);
            return result;
        }

        public IEnumerable<string> ShowUsers(bool full = false)
        {
            var result = _robustService.ShowUsers(full);
            return result;
        }

        public string ShowConnections()
        {
            var result = _robustService.ShowConnections();
            return result;
        }

        public string ShowCircuits()
        {
            var result = _robustService.ShowCircuits();
            return result;
        }

        public string ShowPendingObjects()
        {
            var result = _robustService.ShowPendingObjects();
            return result;
        }

        public string ShowModules()
        {
            var result = _robustService.ShowModules();
            return result;
        }

        public string ShowRegions()
        {
            var result = _robustService.ShowRegions();
            return result;
        }

        public string ShowRatings()
        {
            var result = _robustService.ShowRatings();
            return result;
        }

        public string Backup()
        {
            var result = _robustService.Backup();
            return result;
        }

        public string CreateRegion(string regionName, string regionFile)
        {
            var result = _robustService.CreateRegion(regionName, regionFile);
            return result;
        }

        public string Restart()
        {
            var result = _robustService.Restart();
            return result;
        }

        public string CommandScript(string script)
        {
            var result = _robustService.CommandScript(script);
            return result;
        }

        public string RemoveRegion(string regionName)
        {
            var result = _robustService.RemoveRegion(regionName);
            return result;
        }

        public string DeleteRegion(string regionName)
        {
            var result = _robustService.DeleteRegion(regionName);
            return result;
        }

        public string CreateEstate(string ownerUUID, string estateName)
        {
            var result = _robustService.CreateEstate(ownerUUID, estateName);
            return result;
        }

        public string SetEstateOwner(int estateId, string ownerUUID)
        {
            var result = _robustService.SetEstateOwner(estateId, ownerUUID);
            return result;
        }

        public string SetEstateName(int estateId, string newName)
        {
            var result = _robustService.SetEstateName(estateId, newName);
            return result;
        }

        public string EstateLinkRegion(int estateId, int regionId)
        {
            var result = _robustService.EstateLinkRegion(estateId, regionId);
            return result;
        }
    }
}

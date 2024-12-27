using OpenSim.Framework;
using OpenSim.RESTful.API.Models;
using OpenSim.RESTful.API.Services;

using OpenMetaverse;

using System.Collections.Generic;
using System.Threading.Tasks;
using OpenSim.Services.Interfaces;

namespace OpenSim.RESTful.API.Controllers
{
    public class GeneralController
    {
        private readonly IGeneralService _generalService;

        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        public async Task<string> GetUptime()
        {
            var uptime = await _generalService.GetServerUptimeAsync();
            return uptime;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _generalService.GetAllUsersAsync();
            return users;
        }

        public string ForceUpdate()
        {
            var result = _generalService.ForceUpdate();
            return result;
        }

        public string ChangeRegion(string regionName)
        {
            var result = _generalService.ChangeRegion(regionName);
            return result;
        }

        public string SaveXml(string fileName)
        {
            var result = _generalService.SaveXml(fileName);
            return result;
        }

        public string SaveXml2(string fileName)
        {
            var result = _generalService.SaveXml2(fileName);
            return result;
        }

        public string LoadXml(string fileName, bool newUID = false, Vector3? position = null)
        {
            var result = _generalService.LoadXml(fileName, newUID, position);
            return result;
        }

        public string LoadXml2(string fileName)
        {
            var result = _generalService.LoadXml2(fileName);
            return result;
        }

        public string SavePrimsXml2(string primName, string fileName)
        {
            var result = _generalService.SavePrimsXml2(primName, fileName);
            return result;
        }

        public string LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null)
        {
            var result = _generalService.LoadOar(oarPath, merge, skipAssets, defaultUser, options);
            return result;
        }

        public string SaveOar(string oarPath, string options = null)
        {
            var result = _generalService.SaveOar(oarPath, options);
            return result;
        }

        public string EditScale(string primName, float x, float y, float z)
        {
            var result = _generalService.EditScale(primName, x, y, z);
            return result;
        }

        public string RotateScene(float degrees, float centerX = 128, float centerY = 128)
        {
            var result = _generalService.RotateScene(degrees, centerX, centerY);
            return result;
        }

        public string ScaleScene(float factor)
        {
            var result = _generalService.ScaleScene(factor);
            return result;
        }

        public string TranslateScene(float xOffset, float yOffset, float zOffset)
        {
            var result = _generalService.TranslateScene(xOffset, yOffset, zOffset);
            return result;
        }

        public string KickUser(string firstName, string lastName, bool force = false, string message = null)
        {
            var result = _generalService.KickUser(firstName, lastName, force, message);
            return string.Join(", ", result);
        }

        //public string ShowUsers(bool full = false)
        //{
        //    var result = _generalService.ShowUsers(full);
        //    return string.Join(", ", result);
        //}

        public string ShowConnections()
        {
            var result = _generalService.ShowConnections();
            return string.Join(", ", result);
        }

        public string ShowCircuits()
        {
            var result = _generalService.ShowCircuits();
            return string.Join(", ", result);
        }

        public string ShowPendingObjects()
        {
            var result = _generalService.ShowPendingObjects();
            return result;
        }

        public string ShowModules()
        {
            var result = _generalService.ShowModules();
            return result;
        }

        public string ShowRegions()
        {
            var result = _generalService.ShowRegions();
            return result;
        }

        public string ShowRatings()
        {
            var result = _generalService.ShowRatings();
            return result;
        }

        public string Backup()
        {
            var result = _generalService.Backup();
            return result;
        }

        public string CreateRegion(string regionName, string regionFile)
        {
            var result = _generalService.CreateRegion(regionName, regionFile);
            return result;
        }

        public string Restart()
        {
            var result = _generalService.Restart();
            return result;
        }

        public string CommandScript(string script)
        {
            var result = _generalService.CommandScript(script);
            return result;
        }

        public string RemoveRegion(string regionName)
        {
            var result = _generalService.RemoveRegion(regionName);
            return result;
        }

        public string DeleteRegion(string regionName)
        {
            var result = _generalService.DeleteRegion(regionName);
            return result;
        }

        public string CreateEstate(string ownerUUID, string estateName)
        {
            var result = _generalService.CreateEstate(ownerUUID, estateName);
            return result;
        }

        public string SetEstateOwner(int estateId, string ownerUUID)
        {
            var result = _generalService.SetEstateOwner(estateId, ownerUUID);
            return result;
        }

        public string SetEstateName(int estateId, string newName)
        {
            var result = _generalService.SetEstateName(estateId, newName);
            return result;
        }

        public string EstateLinkRegion(int estateId, int regionId)
        {
            var result = _generalService.EstateLinkRegion(estateId, regionId);
            return result;
        }
    }
}

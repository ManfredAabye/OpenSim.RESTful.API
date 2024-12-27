using System.Collections.Generic;
using System.Threading.Tasks;

using OpenMetaverse;

using OpenSim.Framework;
using OpenSim.RESTful.API.Models;

namespace OpenSim.RESTful.API.Services
{
    public interface IGeneralService
    {
        Task<string> GetServerUptimeAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();

        string ForceUpdate();
        string ChangeRegion(string regionName);
        string SaveXml(string fileName);
        string SaveXml2(string fileName);
        string LoadXml(string fileName, bool newUID = false, Vector3? position = null);
        string LoadXml2(string fileName);
        string SavePrimsXml2(string primName, string fileName);
        string LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null);
        string SaveOar(string oarPath, string options = null);
        string EditScale(string primName, float x, float y, float z);
        string RotateScene(float degrees, float centerX = 128, float centerY = 128);
        string ScaleScene(float factor);
        string TranslateScene(float xOffset, float yOffset, float zOffset);
        string KickUser(string firstName, string lastName, bool force = false, string message = null);
        IEnumerable<string> ShowUsers(bool full = false);
        string ShowConnections();
        string ShowCircuits();
        string ShowPendingObjects();
        string ShowModules();
        string ShowRegions();
        string ShowRatings();
        string Backup();
        string CreateRegion(string regionName, string regionFile);
        string Restart();
        string CommandScript(string script);
        string RemoveRegion(string regionName);
        string DeleteRegion(string regionName);
        string CreateEstate(string ownerUUID, string estateName);
        string SetEstateOwner(int estateId, string ownerUUID);
        string SetEstateName(int estateId, string newName);
        string EstateLinkRegion(int estateId, int regionId);
    }
}

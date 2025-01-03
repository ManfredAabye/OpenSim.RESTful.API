using System.Collections.Generic;
using System.Threading.Tasks;

using Nini.Config;

using OpenMetaverse;

using OpenSim.Framework;
using OpenSim.Services.Interfaces;

namespace OpenSim.RESTful.API.Services
{
    public interface IRobustService
    {
        void Initialize(IConfigSource config);
        void Start(IConfigSource config, IRegistryCore registry);
        void FinishedStartup();
        Task<string> SomeRobustCommandAsync();

        Task<IEnumerable<RegionInfo>> GetAllRegionsAsync();
        Task<RegionInfo> GetRegionDetailsAsync(string regionName);
        Task<string> CreateUserAsync(string firstName, string lastName, string password, string email);
        Task<string> ResetUserPasswordAsync(string userId, string newPassword);
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
        //IEnumerable<string> ShowUsers(bool full = false);
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

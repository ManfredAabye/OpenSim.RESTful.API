using System.Collections.Generic;
using System.Threading.Tasks;

using OpenMetaverse;

using OpenSim.Framework;
using OpenSim.RESTful.API.Helpers;
using OpenSim.RESTful.API.Models;
using OpenSim.Services.Interfaces;

namespace OpenSim.RESTful.API.Services
{
    public class SimulatorService : ISimulatorService
    {
        private readonly IConsole _console;
        private readonly string _storageProvider;
        private readonly string _connectionString;

        public SimulatorService(IConsole console, ConfigReader configReader)
        {
            _console = console;

            if (configReader.IsSimulatorServiceEnabled())
            {
                _storageProvider = configReader.GetSimulatorStorageProvider();
                _connectionString = configReader.GetSimulatorConnectionString();
            }
        }

        public async Task<string> ShutdownRegionAsync(string regionName)
        {
            var result = _console.ExecuteCommand($"shutdown region {regionName}");
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<RegionInfo>> GetAllSimulatorRegionsAsync()
        {
            var result = _console.ExecuteCommand("show regions");
            var regions = ResponseParser.ParseRegions(result);
            return await Task.FromResult(regions);
        }

        public string SaveXml(string fileName)
        {
            var result = _console.ExecuteCommand($"save xml {fileName}");
            return result;
        }

        public string SaveXml2(string fileName)
        {
            var result = _console.ExecuteCommand($"save xml2 {fileName}");
            return result;
        }

        public string LoadXml(string fileName, bool newUID = false, Vector3? position = null)
        {
            var positionString = position.HasValue ? $"{position.Value.X} {position.Value.Y} {position.Value.Z}" : "";
            var result = _console.ExecuteCommand($"load xml {fileName} {(newUID ? "newUID" : "")} {positionString}");
            return result;
        }

        public string LoadXml2(string fileName)
        {
            var result = _console.ExecuteCommand($"load xml2 {fileName}");
            return result;
        }

        public string SavePrimsXml2(string primName, string fileName)
        {
            var result = _console.ExecuteCommand($"save prims xml2 {primName} {fileName}");
            return result;
        }

        public string LoadOar(string oarPath, bool merge = false, bool skipAssets = false, string defaultUser = null, string options = null)
        {
            var optionsString = options != null ? $" {options}" : "";
            var result = _console.ExecuteCommand($"load oar {oarPath} {(merge ? "merge" : "")} {(skipAssets ? "skipAssets" : "")} {defaultUser} {optionsString}");
            return result;
        }

        public string SaveOar(string oarPath, string options = null)
        {
            var optionsString = options != null ? $" {options}" : "";
            var result = _console.ExecuteCommand($"save oar {oarPath}{optionsString}");
            return result;
        }

        public string EditScale(string primName, float x, float y, float z)
        {
            var result = _console.ExecuteCommand($"edit scale {primName} {x} {y} {z}");
            return result;
        }

        public string RotateScene(float degrees, float centerX = 128, float centerY = 128)
        {
            var result = _console.ExecuteCommand($"rotate scene {degrees} {centerX} {centerY}");
            return result;
        }

        public string ScaleScene(float factor)
        {
            var result = _console.ExecuteCommand($"scale scene {factor}");
            return result;
        }

        public string TranslateScene(float xOffset, float yOffset, float zOffset)
        {
            var result = _console.ExecuteCommand($"translate scene {xOffset} {yOffset} {zOffset}");
            return result;
        }

        public string KickUser(string firstName, string lastName, bool force = false, string message = null)
        {
            var forceFlag = force ? "force" : "";
            var result = _console.ExecuteCommand($"kick user {firstName} {lastName} {forceFlag} {message}");
            return result;
        }

        //public IEnumerable<string> ShowUsers(bool full = false)
        //{
        //    var fullFlag = full ? "full" : "";
        //    var result = _console.ExecuteCommand($"show users {fullFlag}");
        //    var users = ResponseParser.ParseUsers(result);
        //    return users;
        //}

        public string ShowConnections()
        {
            var result = _console.ExecuteCommand("show connections");
            return result;
        }

        public string ShowCircuits()
        {
            var result = _console.ExecuteCommand("show circuits");
            return result;
        }

        public string ShowPendingObjects()
        {
            var result = _console.ExecuteCommand("show pending objects");
            return result;
        }

        public string ShowModules()
        {
            var result = _console.ExecuteCommand("show modules");
            return result;
        }

        public string ShowRegions()
        {
            var result = _console.ExecuteCommand("show regions");
            return result;
        }

        public string ShowRatings()
        {
            var result = _console.ExecuteCommand("show ratings");
            return result;
        }

        public string Backup()
        {
            var result = _console.ExecuteCommand("backup");
            return result;
        }

        public string CreateRegion(string regionName, string regionFile)
        {
            var result = _console.ExecuteCommand($"create region {regionName} {regionFile}");
            return result;
        }

        public string Restart()
        {
            var result = _console.ExecuteCommand("restart");
            return result;
        }

        public string CommandScript(string script)
        {
            var result = _console.ExecuteCommand($"command script {script}");
            return result;
        }

        public string RemoveRegion(string regionName)
        {
            var result = _console.ExecuteCommand($"remove region {regionName}");
            return result;
        }

        public string DeleteRegion(string regionName)
        {
            var result = _console.ExecuteCommand($"delete region {regionName}");
            return result;
        }

        public string CreateEstate(string ownerUUID, string estateName)
        {
            var result = _console.ExecuteCommand($"create estate {ownerUUID} {estateName}");
            return result;
        }

        public string SetEstateOwner(int estateId, string ownerUUID)
        {
            var result = _console.ExecuteCommand($"set estate owner {estateId} {ownerUUID}");
            return result;
        }

        public string SetEstateName(int estateId, string newName)
        {
            var result = _console.ExecuteCommand($"set estate name {estateId} {newName}");
            return result;
        }

        public string EstateLinkRegion(int estateId, int regionId)
        {
            var result = _console.ExecuteCommand($"estate link region {estateId} {regionId}");
            return result;
        }
    }
}

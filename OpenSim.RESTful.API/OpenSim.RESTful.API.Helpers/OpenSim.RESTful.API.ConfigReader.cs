using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nini.Config;

namespace OpenSim.RESTful.API.Helpers
{
    public class ConfigReader
    {
        private readonly IConfigSource _openSimSource;
        private readonly IConfigSource _gridCommonSource;
        private readonly IConfigSource _robustSource;

        public ConfigReader(string openSimConfigPath, string gridCommonConfigPath, string robustConfigPath)
        {
            _openSimSource = new IniConfigSource(openSimConfigPath);
            _gridCommonSource = new IniConfigSource(gridCommonConfigPath);
            _robustSource = new IniConfigSource(robustConfigPath);
        }

        public bool IsSimulatorServiceEnabled()
        {
            return _openSimSource.Configs["RESTfulService"].GetBoolean("enabled", false);
        }

        public string GetSimulatorStorageProvider()
        {
            return _gridCommonSource.Configs["DatabaseService"].Get("StorageProvider");
        }

        public string GetSimulatorConnectionString()
        {
            return _gridCommonSource.Configs["DatabaseService"].Get("ConnectionString");
        }

        public bool IsGeneralServiceEnabled()
        {
            return _openSimSource.Configs["RESTfulService"].GetBoolean("enabled", false);
        }

        public bool IsRobustServiceEnabled()
        {
            return _robustSource.Configs["RESTfulService"].GetBoolean("enabled", false);
        }

        public string GetRobustStorageProvider()
        {
            return _robustSource.Configs["DatabaseService"].Get("StorageProvider");
        }

        public string GetRobustConnectionString()
        {
            return _robustSource.Configs["DatabaseService"].Get("ConnectionString");
        }
    }
}
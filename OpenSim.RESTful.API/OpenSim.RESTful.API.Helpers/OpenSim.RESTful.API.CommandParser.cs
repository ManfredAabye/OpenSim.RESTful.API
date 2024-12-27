using OpenMetaverse;
using OpenSim.Framework;
using OpenSim.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System;

namespace OpenSim.RESTful.API.Helpers
{
    public static class CommandParser
    {
        public static string BuildRegionShowCommand(string regionName)
        {
            return $"show region \"{regionName}\"";
        }

        /// <summary>
        /// Constructs a command for creating a user.
        /// </summary>
        public static string CreateUserCommand(string firstName, string lastName, string password, string email)
        {
            return $"create user {firstName} {lastName} {password} {email}";
        }

        /// <summary>
        /// Constructs a command for resetting a user's password.
        /// </summary>
        public static string ResetUserPasswordCommand(string userId, string newPassword)
        {
            return $"reset user password {userId} {newPassword}";
        }

        /// <summary>
        /// Constructs a command for forcing an update.
        /// </summary>
        public static string ForceUpdateCommand()
        {
            return "force update";
        }

        /// <summary>
        /// Constructs a command for changing a region.
        /// </summary>
        public static string ChangeRegionCommand(string regionName)
        {
            return $"change region {regionName}";
        }

        /// <summary>
        /// Constructs a command for saving a region to XML.
        /// </summary>
        public static string SaveXmlCommand(string fileName)
        {
            return $"save xml {fileName}";
        }

        /// <summary>
        /// Constructs a command for loading a region from XML.
        /// </summary>
        public static string LoadXmlCommand(string fileName, bool newUID = false, Vector3? position = null)
        {
            var positionString = position.HasValue ? $"{position.Value.X} {position.Value.Y} {position.Value.Z}" : "";
            return $"load xml {fileName} {(newUID ? "newUID" : "")} {positionString}";
        }
        
        // Weitere Kommandos hier...
    }
}

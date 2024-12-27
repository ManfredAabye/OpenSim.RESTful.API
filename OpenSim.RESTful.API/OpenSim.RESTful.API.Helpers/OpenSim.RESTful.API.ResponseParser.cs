using System;
using System.Collections.Generic;
using System.Text.Json;

using OpenMetaverse;

using OpenSim.Framework;
using OpenSim.RESTful.API.Models;

namespace OpenSim.RESTful.API.Helpers
{
    public static class ResponseParser
    {
        public static string ParseCommandResponse(string rawResponse)
        {
            var lines = rawResponse.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var responseDict = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var split = line.Split(':', 2, StringSplitOptions.TrimEntries);
                if (split.Length == 2)
                {
                    responseDict[split[0]] = split[1];
                }
            }

            return JsonSerializer.Serialize(responseDict);
        }

        public static string ParseError(string errorMessage)
        {
            var errorResponse = new
            {
                success = false,
                error = errorMessage
            };
            return JsonSerializer.Serialize(errorResponse);
        }

        public static IEnumerable<RegionInfo> ParseRegions(string result)
        {
            var regions = new List<RegionInfo>();
            var lines = result.Split('\n');
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                if (parts.Length > 1)
                {
                    var region = new RegionInfo
                    {
                        RegionName = parts[0],
                        RegionID = new UUID(parts[1])
                    };
                    regions.Add(region);
                }
            }
            return regions;
        }

        public static RegionInfo ParseRegion(string result)
        {
            var parts = result.Split(' ');
            if (parts.Length > 1)
            {
                return new RegionInfo
                {
                    RegionName = parts[0],
                    RegionID = new UUID(parts[1])
                };
            }
            return null;
        }

        public static IEnumerable<User> ParseUsers(string result)
        {
            var users = new List<User>();
            var lines = result.Split('\n');
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Split(' ');
                    if (parts.Length >= 2)
                    {
                        var user = new User
                        {
                            FirstName = parts[0],
                            LastName = parts[1]
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}

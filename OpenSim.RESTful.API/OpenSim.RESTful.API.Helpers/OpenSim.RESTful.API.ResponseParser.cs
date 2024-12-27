using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenSim.RESTful.API.Helpers
{
    public static class ResponseParser
    {
        /// <summary>
        /// Parses a raw string response from the OpenSim command line interface into JSON.
        /// </summary>
        public static string ParseCommandResponse(string rawResponse)
        {
            // Example: Process the raw response into a structured format
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

        /// <summary>
        /// Converts errors to a standardized JSON response.
        /// </summary>
        public static string ParseError(string errorMessage)
        {
            var errorResponse = new
            {
                success = false,
                error = errorMessage
            };
            return JsonSerializer.Serialize(errorResponse);
        }
    }
}

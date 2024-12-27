using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSim.Framework;

namespace OpenSim.RESTful.API.Helpers
{
    public class ConsoleImplementation : IConsole
    {
        public IScene ConsoleScene { get; set; }

        public void Output(string format)
        {
            Console.WriteLine(format);
        }

        public void Output(string format, params object[] components)
        {
            Console.WriteLine(format, components);
        }

        public string Prompt(string p)
        {
            Console.Write(p);
            return Console.ReadLine();
        }

        public string Prompt(string p, string def)
        {
            Console.Write($"{p} (default: {def}): ");
            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? def : input;
        }

        public string Prompt(string p, List<char> excludedCharacters)
        {
            // Implementiere die Logik
            return "";
        }

        public string Prompt(string p, string def, List<char> excludedCharacters, bool echo = true)
        {
            // Implementiere die Logik
            return "";
        }

        public string Prompt(string prompt, string defaultresponse, List<string> options)
        {
            // Implementiere die Logik
            return "";
        }
    }
}

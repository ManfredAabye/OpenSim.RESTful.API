using System;
using OpenSim.Framework;
using OpenSim.RESTful.API.Services;
using OpenSim.RESTful.API.Controllers;
using OpenSim.RESTful.API.Helpers;

public class Program
{
    public static void Main(string[] args)
    {
        // Pfade zu den Konfigurationsdateien
        string openSimConfigPath = "OpenSim.ini";
        string gridCommonConfigPath = "config-include/GridCommon.ini";
        string robustConfigPath = "Robust.ini";

        // Erstelle eine Instanz von ConfigReader
        ConfigReader configReader = new ConfigReader(openSimConfigPath, gridCommonConfigPath, robustConfigPath);

        IConsole console = new ConsoleImplementation(); // Verwende die konkrete Implementierung von IConsole

        // Initialisierung der Dienste basierend auf den Konfigurationswerten
        ISimulatorService simulatorService = null;
        IGeneralService generalService = null;
        IRobustService robustService = null;

        if (configReader.IsGeneralServiceEnabled())
        {
            generalService = new GeneralService(console, configReader);
            Console.WriteLine("General service is enabled.");
        }
        else
        {
            Console.WriteLine("General service is disabled.");
        }

        if (configReader.IsSimulatorServiceEnabled())
        {
            simulatorService = new SimulatorService(console, configReader);
            Console.WriteLine("Simulator service is enabled.");
        }
        else
        {
            Console.WriteLine("Simulator service is disabled.");
        }

        if (configReader.IsRobustServiceEnabled())
        {
            robustService = new RobustService(console, configReader);
            Console.WriteLine("Robust service is enabled.");
        }
        else
        {
            Console.WriteLine("Robust service is disabled.");
        }

        // Initialisierung der Controller basierend auf den verfügbaren Diensten
        if (simulatorService != null)
        {
            var simulatorController = new SimulatorController(simulatorService);
            // Beispiel: simulatorController.ShutdownRegion("regionName");
        }

        if (generalService != null)
        {
            var generalController = new GeneralController(generalService);
            // Beispiel: Aufrufen einer Methode des GeneralController
        }

        if (robustService != null)
        {
            var robustController = new RobustServiceController(robustService);
            // Beispiel: Aufrufen einer Methode des RobustController
        }
    }
}
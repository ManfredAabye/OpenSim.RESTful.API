using System;
using OpenSim.Framework;
using OpenSim.RESTful.API.Services;
using OpenSim.RESTful.API.Controllers;
using OpenSim.RESTful.API.Helpers;

public class Program
{
    public static void Main(string[] args)
    {
        IConsole console = new ConsoleImplementation(); // Verwende die konkrete Implementierung von IConsole

        var simulatorService = new SimulatorService(console);
        var generalService = new GeneralService(console);
        var robustService = new RobustService(console);

        var simulatorController = new SimulatorController(simulatorService);
        var generalController = new GeneralController(generalService);
        var robustController = new RobustServiceController(robustService);

        // Hier können Sie die Controller verwenden, um die gewünschten Funktionen auszuführen
        // Beispiel: simulatorController.ShutdownRegion("regionName");
    }
}

using System;

public class Program
{
    public static void Main(string[] args)
    {
        var simulatorService = new OpenSim.RESTful.API.Services.SimulatorService();
        var generalService = new OpenSim.RESTful.API.Services.GeneralService();
        var robustService = new OpenSim.RESTful.API.Services.RobustService();

        var simulatorController = new OpenSim.RESTful.API.Controllers.SimulatorController(simulatorService);
        var generalController = new OpenSim.RESTful.API.Controllers.GeneralController(generalService);
        var robustController = new OpenSim.RESTful.API.Controllers.RobustServiceController(robustService);

        // Hier können Sie die Controller verwenden, um die gewünschten Funktionen auszuführen
        // Beispiel: simulatorController.ShutdownRegion("regionName");
    }
}

Du kannst diese Commands in eine RESTful API umbauen und sie in einer Schnittstelle wie `iOpenSim.cs` einfügen. Hier ist ein Ansatz:

1. **Definiere eine REST-Schnittstelle in `iOpenSim.cs`**:
   Die Schnittstelle sollte die Befehle als REST-Endpunkte (GET, POST, etc.) deklarieren.

2. **Implementiere die Endpunkte in der entsprechenden Klasse**:
   Schreibe eine Klasse, die diese Endpunkte implementiert. Jeder Konsolenbefehl wird zu einem REST-Endpunkt umgewandelt.

3. **Benutze einen HTTP-Server**:
   OpenSim verwendet bereits `MainServer`, daher kannst du diesen nutzen, um die REST-Endpoints zu registrieren.

### Beispiel für eine REST-Schnittstelle
```csharp
public interface iOpenSim
{
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
    IEnumerable<string> ShowUsers(bool full = false);
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
```

### Beispiel für die Implementierung eines REST-Endpunkts
```csharp
public class OpenSimRestHandler : iOpenSim
{
    public string ForceUpdate()
    {
        // Logik für "force update"
        return "Force update triggered successfully.";
    }

    public string ChangeRegion(string regionName)
    {
        // Logik für "change region"
        return $"Region changed to {regionName}.";
    }

    public string SaveXml(string fileName)
    {
        // Logik für "save xml"
        return $"Region saved as XML to {fileName}.";
    }

    // Weitere Methoden wie SaveXml2, LoadXml usw.
}
```

### Registriere die Endpunkte im HTTP-Server
Nutze OpenSims `MainServer` oder einen eigenen HTTP-Listener, um die Endpunkte zu registrieren.

```csharp
public void RegisterRestEndpoints()
{
    MainServer.Instance.AddHTTPHandler("/api/force-update", HttpMethod.POST, ForceUpdateHandler);
    MainServer.Instance.AddHTTPHandler("/api/change-region", HttpMethod.POST, ChangeRegionHandler);
    // Weitere Endpunkte hier registrieren
}

private Hashtable ForceUpdateHandler(Hashtable request)
{
    string response = ForceUpdate();
    return BuildResponse(response);
}

private Hashtable ChangeRegionHandler(Hashtable request)
{
    string regionName = request["regionName"].ToString();
    string response = ChangeRegion(regionName);
    return BuildResponse(response);
}

private Hashtable BuildResponse(string message)
{
    return new Hashtable
    {
        ["int_response_code"] = 200,
        ["str_response_string"] = message,
        ["content_type"] = "application/json"
    };
}
```

### Vorteile der RESTful API
- **Flexibilität**: Befehle können von beliebigen Clients (Web, CLI, Anwendungen) aufgerufen werden.
- **Skalierbarkeit**: Unterstützt HTTP/HTTPS und ist leicht mit anderen Diensten zu integrieren.
- **Standardisierung**: Nutzt HTTP-Methoden und gängige Konventionen.

Mit diesem Ansatz kannst du alle Konsolenbefehle über eine RESTful API zugänglich machen und sie sauber in die bestehende OpenSim-Infrastruktur einfügen.




--------------------------------------------------------------------------------------------------------------------------------------------




Die Befehle in eine RESTful API umwandeln und in eine Schnittstelle wie `iOpenSim.cs` einfügen.

### 1. Definiere eine REST-Schnittstelle in `iOpenSim.cs`

Die Schnittstelle sollte die Befehle als REST-Endpunkte (GET, POST, etc.) deklarieren.

```csharp
public interface iOpenSim
{
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
    IEnumerable<string> ShowUsers(bool full = false);
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
```

### 2. Implementiere die Endpunkte in der entsprechenden Klasse

Schreibe eine Klasse, die diese Endpunkte implementiert. Jeder Konsolenbefehl wird zu einem REST-Endpunkt umgewandelt.

```csharp
public class OpenSimRestHandler : iOpenSim
{
    public string ForceUpdate()
    {
        // Logik für "force update"
        return "Force update triggered successfully.";
    }

    public string ChangeRegion(string regionName)
    {
        // Logik für "change region"
        return $"Region changed to {regionName}.";
    }

    public string SaveXml(string fileName)
    {
        // Logik für "save xml"
        return $"Region saved as XML to {fileName}.";
    }

    // Weitere Methoden wie SaveXml2, LoadXml usw.
}
```

### 3. Benutze einen HTTP-Server

Nutze OpenSims `MainServer` oder einen eigenen HTTP-Listener, um die REST-Endpoints zu registrieren.

```csharp
public void RegisterRestEndpoints()
{
    MainServer.Instance.AddHTTPHandler("/api/force-update", HttpMethod.POST, ForceUpdateHandler);
    MainServer.Instance.AddHTTPHandler("/api/change-region", HttpMethod.POST, ChangeRegionHandler);
    // Weitere Endpunkte hier registrieren
}

private Hashtable ForceUpdateHandler(Hashtable request)
{
    string response = ForceUpdate();
    return BuildResponse(response);
}

private Hashtable ChangeRegionHandler(Hashtable request)
{
    string regionName = request["regionName"].ToString();
    string response = ChangeRegion(regionName);
    return BuildResponse(response);
}

private Hashtable BuildResponse(string message)
{
    return new Hashtable
    {
        ["int_response_code"] = 200,
        ["str_response_string"] = message,
        ["content_type"] = "application/json"
    };
}
```

### Vorteile der RESTful API

- **Flexibilität**: Befehle können von beliebigen Clients (Web, CLI, Anwendungen) aufgerufen werden.
- **Skalierbarkeit**: Unterstützt HTTP/HTTPS und ist leicht mit anderen Diensten zu integrieren.
- **Standardisierung**: Nutzt HTTP-Methoden und gängige Konventionen.

Mit diesem Ansatz kannst du alle Konsolenbefehle über eine RESTful API zugänglich machen und sie sauber in die bestehende OpenSim-Infrastruktur einfügen.




---------------------------------------------------------------------------------------------------------------------------




= All Commands =

== General Server Commands ==

These commands are available in both simulator and robust consoles.

=== General ===

* command-script [scriptfile] - Runs a command script containing console commands.
* quit - shutdown the server.
* show info - show server information (version and startup path).  Before OpenSimulator 0.7.5 this is only available on the simulator console.
* show uptime - show server startup time and uptime.  Before OpenSimulator 0.7.5 this is only available on the simulator console.
* show version - show server version.  Before OpenSimulator 0.7.5 this is only available on the simulator console.
* shutdown - synonym for quit
* get log level - In OpenSimulator 0.7.5 and later, print the current console logging level.  In OpenSimulator 0.7.4 and earlier please use the "set log level" command instead without a level parameter.
* set log level [level] - change the console logging level only. For example, off or debug. See [[Logging]] for more information.  In OpenSimulator 0.7.4 and earlier, if called without the level argument prints the current level.  In OpenSimulator 0.7.5 and later please use the "get log level" command instead.  Only available on ROBUST console from OpenSimulator 0.7.5.

=== Debug ===

* debug http [<level>] - Turn on/off extra logging for HTTP request debugging.  Only available on robust console from commit 94517c8 (dev code post 0.7.3.1).  In current development code (for OpenSimulator 0.7.5) this is debug http in|out|all [<level>] since outbound HTTP messages can also now be logged (this was only possible for inbound before). For more information on this command, see [[Debugging]].

* debug threadpool level <level> - Turn on/off logging of activity in the main threadpool. For more information, see [[General-Purpose Threadpool]].

== Simulator Commands ==

=== General ===

* change region <region name> - subsequent commands apply only to the specified region. If region name is "root" then all regions are selected
* debug packet <level> - Turn on packet debugging, where OpenSimulator prints out summaries of incoming and outgoing packets for viewers, depending on the level set
* emergency-monitoring - turn emergency debugging monitoring mode on or off.
* help [<command>] - Get general command list or more detailed help on a specific command or set of commands
* link-mapping - Set a local grid co-ordinate to link to a remote hypergrid 
* link-region - Link a HyperGrid region. Not sure how this differs from link-mapping
* modules list - List modules
* modules load <name> - Load a module
* modules unload <name> - Unload a module
* monitor report - Returns a variety of statistics about the current region and/or simulator
* set terrain heights <corner> <min> <max> [<x>] [<y>] - Sets the terrain texture heights on corner #<corner> to <min>/<max>, if <x> or <y> are specified, it will only set it on regions with a matching coordinate. Specify -1 in <x> or <y> to wildcard that coordinate. Corner # SW = 0, NW = 1, SE = 2, NE = 3.
* set terrain texture <number> <uuid> [<x>] [<y>] - Sets the terrain <number> to <uuid>, if <x> or <y> are specified, it will only set it on regions with a matching coordinate. Specify -1 in <x> or <y> to wildcard that coordinate.
* show caps - show all registered capabilities URLs
:NOTE: In OpenSimulator 0.7.1, "show capabilities" is shown as a result for help command, but actually only "show caps" will be accepted. ([http://opensimulator.org/mantis/view.php?id=5467 #5467])
* set water height # - sets the height simulator wide or single region if you use change region.
* show circuits - Show agent circuit data
* show connections - show connections data
* show http-handlers - show all registered http handlers
* show hyperlinks - list hg regions
* show modules - show module data
* show pending-objects - show number of objects in the pending queues of all viewers
* show pqueues [full] - show priority queue data for each client. Without the 'full' option, only root agents are shown. With the 'full' option child agents are also shown.
* show queues - Show queue data for agent connections.
* show threads - shows the persistent threads registered with the system. Does not include threadpool threads. 
* show throttles [full] - Show throttle data for each client connection, and the maximum allowed for each connection by the server. Without the 'full' option, only root agents are shown. With the 'full' option child agents are also shown.
* unlink-region <local name> - unlink a hypergrid region

=== Appearance Commands ===

* appearance find <uuid-or-start-of-uuid> - Find out which avatar uses the given asset as a baked texture, if any.
* appearance rebake <first-name> <last-name> - Send a request to the user's viewer for it to rebake and reupload its appearance textures.
* appearance send [<first-name> <last-name>] - Send appearance data for each avatar in the simulator to other viewers.
* appearance show [<first-name> <last-name>] - Show appearance information for avatars.

Only exists in development code at the moment.

=== Archive Commands ===

* load iar <first> <last> <inventory path> <password> [<archive path>] - Load user inventory archive. See [[Inventory Archives]].
* load oar [filename] - load an OpenSimulator archive. This entirely replaces the current region. Default filename is '''region.oar'''. See [[OpenSim Archives]].
* load xml [-newIDs [<x> <y> <z>]] - Load a region's data from XML format (0.7.*: DEPRECATED and may be REMOVED soon. Use "load xml2" instead)
:those xml are the result of the export save or *export save-all
* load xml2 [filename] - optional parameters not supported for XML2 format as at 1-Jul-2008 
* save iar <first> <last> <inventory path> <password> [<archive path>] - Save user inventory archive. See [[Inventory Archives]]
* save oar [filename] - save the current region to an OpenSimulator archive. Default filename is '''region.oar'''. See [[OpenSim Archives]].
* save prims xml2 [<prim name> <file name>] - Save named prim to XML2
* save xml [filename] - save prims to XML 
* save xml2 [filename] - save prims to XML (Format 2 - rearrangement of some nodes, to make loading/saving easier) 

=== Asset Commands ===

The fcache commands only currently appearance if you are using the fcache asset cache.  This is the default on OpenSimulator.

* fcache assets - Attempt a deep scan and cache of all assets in all scenes
* fcache clear [file] [memory] - Remove all assets in the cache.  If file or memory is specified then only this cache is cleared.
* fcache expire <datetime> - Purge cached assets older then the specified date/time
* fcache status - Display cache status
* j2k decode <ID> - Do JPEG2000 decoding of an asset.

=== Config Commands ===

* config get [<section>] [<key>] - Get the current configuration, either for a particular key, a particular section or the whole config.
* config save <path> - Save the current configuration to a file.
* config set <section> <key> - Set a particular configuration value. On the whole, this is useless since neither OpenSimulator nor modules dynamically reload config values.
* config show [<section>] [<key>] - Synonym for 'config get'

=== Land Commands ===

* land show - Shows all parcels on the current region.
* land clear - Clears all parcels on the land.

=== Map Commands ===

* export-map [<path>] - Save an image of the world map (default name is exportmap.jpg)
* generate map - Regenerates and stores map tile.  Only in development code post 0.7.6.

=== Object Commands ===

* backup - Persist currently unsaved object changes immediately instead of waiting for the normal persistence call.  This shouldn't normally be required - the simulator persists region objects automatically at regular intervals and on shutdown.
* delete object creator <UUID> - Delete a scene object by creator
* delete object name [--regex] <name> - Delete a scene object by name.
* delete object outside - Delete all scene objects outside region boundaries.  This is currently if z < 0 or z > 10000.  Object outside these bounds have been known to cause issues with OpenSimulator's use of some physics engines (such as the Open Dynamics Engine).
* delete object owner <UUID> - Delete a scene object by owner
* delete object id <UUID-or-localID> - Delete a scene object by uuid or localID. Pre 0.7.5, this was "show object uuid".
* dump object id <UUID-or-localID> - Dump the serialization of the given object to a file for debug purposes.
* edit scale <name> <x> <y> <z> - Change the scale of a named prim
* force update - Force the region to send all clients updates about all objects.
* show object name [--regex] <name> - Show details of scene objects with the given name.
* show object id <UUID-or-localID> - Show details of a scene object with the given UUID or localID. Pre 0.7.5, this was "show object uuid".
* show part name [--regex] <name> - Show details of scene object parts with the given name.
* show part id <UUID-or-localID> - Show details of a scene object parts with the given UUID or localID. Pre 0.7.5, this was "show object uuid".

=== Estate Commands ===
* reload estate - reload estate data
* estate link region <estate ID> <region ID> - Attaches the specified region to the specified estate.
* estate show - This command will show the estate name, ID, and owner for regions currently running in the simulator. This list does not necessarily include all estates that are present in the database.  
Sample usage: 
 estate show<enter>
 Estate information for region TestRegion
 Estate Name ID Owner
 My Estate 103 Test User
* estate set name <estate ID> <new name> - Rename an estate
* estate set owner <estate ID> <FirstName> <LastName> - Change the owner of an estate. This command supports two forms; this one uses the owner's name.
* estate set owner <estate ID> <owner UUID> - Change the owner of an estate. This command supports two forms; this one uses the owner's UUID.
* estate create <owner UUID> <estate name> - Must be a user UUID which you can get from 'show names'

=== Region Commands ===
* change region <region name> - subsequent commands apply only to the specified region. If region name is "root" then all regions are selected
* create region [name] [filename] - Create a new region 
* delete-region <name> - Delete a region from disk.
* region get - Post OpenSimulator 0.8.0.*.  Show region parameters (Region Name, Region UUID, Location, URI, Owner ID, Flags).
* region restart abort [<message>] - Abort a scheduled region restart, with an optional message
* region restart bluebox <message> <delta seconds>+ - Schedule a region restart. If one delta is given then the region is restarted in delta seconds time. A time to restart is sent to users in the region as a dismissable bluebox notice. If multiple deltas are given then a notice is sent when we reach each delta.
* region restart notice <message> <delta seconds>+ - Schedule a region restart. Same as above except showing a transient notice instead of a dismissable bluebox.
* region set - Post OpenSimulator 0.8.0.*.  Set certain region parameters.  Currently, can set
** agent-limit - The current avatar limit for the region.  More usually this is set via the region/estate dialog in a typical viewer.  This persists over simulator restarts.
** max-agent-limit - The maximum value that agent-limit can have.  Unfortunately, setting it here does not currently persist over server restarts.  For that to happen it must be separately set as the MaxAgents parameter in the region config file.
* remove-region - remove a region from the simulator
* restart - Restarts all sims in this instance
* restart region <regionname> - Restarts just one sim in an instance. Set the console to the region name first, with 'change region <regionname>', or all regions will restart.
* set region flags <Region name> <flags> - Set database flags for region
:Flags can be one of the following:
:'''DefaultRegion'''	Used for new Rez. Random if multiple defined
:'''FallbackRegion'''	Regions we redirect to when the destination is down
:'''RegionOnline'''	Set when a region comes online, unset when it unregisters and DeleteOnUnregister is false
:'''NoDirectLogin'''	Region unavailable for direct logins (by name)
:'''Persistent'''	Don't remove on unregister
:'''LockedOut'''	Don't allow registration
:'''NoMove	'''Don't allow moving this region
:'''Reservation'''	This is an inactive reservation
:'''Authenticate'''	Require authentication
:'''Hyperlink'''	Record represents a HG link
:'''DefaultHGRegion'''	Record represents a default region for hypergrid teleports only.
:Note: flags are additive, there is no way to unset them from the console.
* show neighbours - Shows the local regions' neighbours
* show ratings - Show rating data
* show region - Show region parameters (Region Name, Region UUID, Location, URI, Owner ID, Flags).
* show regions - Show regions data (Region Names, XLocation YLocation coordinates, Region Ports, Estate Names)

=== Scene Commands ===

* debug scene - Turn on scene debugging
* rotate scene <degrees> - Rotates scene around 128,128 axis by x degrees where x=0-360.
* scale scene <factor> - Scales all scene objects by a factor where original size =1.0.
* translate scene <x,y,z> - Translate (move) the entire scene to a new coordinate. Useful for moving a scene to a different location on either a Mega or Variable region. 
(please back up your region before using any of these commands and be aware of possible floating point errors the more they are used.)
 
=== Script Commands ===

These currently only exist in git master OpenSimulator development code post the 0.7.2 release.

* scripts resume [<script-item-uuid>] - Resumes all suspended scripts
* scripts show [<script-item-uuid>] - Show script information. <script-item-uuid> option only exists from git master 82f0e19 (2012-01-14) onwards (post OpenSimulator 0.7.2).
* scripts start [<script-item-uuid>] - Starts all stopped scripts
* scripts stop [<script-item-uuid>] - Stops all running scripts
* scripts suspend [<script-item-uuid>] - Suspends all running scripts

=== Stats Commands ===

* show stats - show useful statistical information for this server. See [[#Frame Statistics Values|Frame Statistics Values]] below for more information.
* stats show - a synonym for "show stats" (OpenSimulator dev code only post 19th March 2014).
* stats record - record stats periodically to a separate log file.
* stats save - save a snapshot of current stats to a file (OpenSimulator dev code only post 19th March 2014).

=== Terrain Commands ===

Some of these may require a sim restart to show properly.
* terrain load - Loads a terrain from a specified file. (see note1)
* terrain load-tile - Loads a terrain from a section of a larger file.
* terrain save - Saves the current heightmap to a specified file.
* terrain save-tile - Saves the current heightmap to the larger file.
* terrain fill - Fills the current heightmap with a specified value.
* terrain elevate - Raises the current heightmap by the specified amount.
* terrain lower - Lowers the current heightmap by the specified amount.
* terrain multiply - Multiplies the heightmap by the value specified.
* terrain bake - Saves the current terrain into the regions baked map.
* terrain revert - Loads the baked map terrain into the regions heightmap.
* terrain newbrushes - Enables experimental brushes which replace the standard terrain brushes.
* terrain show - Shows terrain height at a given co-ordinate.
* terrain stats - Shows some information about the regions heightmap for debugging purposes.
* terrain effect - Runs a specified plugin effect
* terrain flip - Flips the current terrain about the X or Y axis
* terrain rescale - Rescales the current terrain to fit between the given min and max heights
* terrain min - Sets the minimum terrain height to the specified value.
* terrain max - Sets the maximum terrain height to the specified value.
* terrain modify - Provides several area-of-effect terraforming commands.

Note1 : If you have a sim with multiple regions and you want to set all regions on that sim to be from one larger image you can use 'terrain load <file> <width in regions> <height in regions> <regionX> <regionY> where regionX and regionY are the coordinates of the bottom-left region.

=== Tree Commands ===

* tree active - Change activity state for the trees module
* tree freeze - Freeze/Unfreeze activity for a defined copse
* tree load - Load a copse definition from an xml file
* tree plant - Start the planting on a copse
* tree rate - Reset the tree update rate (mSec)
* tree reload - Reload copse definitions from the in-scene trees
* tree remove - Remove a copse definition and all its in-scene trees
* tree statistics - Log statistics about the trees

=== User Commands ===

* alert <message> - send an in-world alert to everyone
* alert-user <first> <last> <message> - send an an in-world alert to a specific user
* bypass permissions &lt;true / false&gt; - Bypass in-world permission checks 
* debug permissions - Turn on permissions debugging
* force permissions - Force permissions on or off.
* kick user <first> <last> [message]: - Kick a user off the simulator
* login disable - Disable user entry to this simulator
* login enable - Enable user entry to this simulator
* login status - Show whether logins to this simulator are enabled or disabled
* show users [full]- show info about currently connected users to this region. Without the 'full' option, only users actually on the region are shown. With the 'full' option child agents of users in neighbouring regions are also shown.
* teleport user <destination> - Teleport a user on this simulator to a specific destination.  Currently only in OpenSimulator development code after the 0.7.3.1 release (commit bf0b817).

=== Windlight/[[LightShare]] Commands ===

* windlight load - Load windlight profile from the database and broadcast
* windlight enable - Enable the windlight plugin
* windlight disable - Disable the windlight plugin

=== [[YEngine]] Commands ===
* yeng help
* yeng reset -all | <part-of-script-name>
* yeng resume - resume script processing
* yeng suspend - suspend script processing
* yeng ls -full -max=<number> -out=<filename> -queues -topcpu
* yeng cvv - show compiler version value
* yeng mvv [<newvalue>] - show migration version value
* yeng tracecalls [yes | no]
* yeng verbose [yes | no]
* yeng pev -all | <part-of-script-name> <event-name> <params...>

== ROBUST Service Commands ==

These can also be accessed on the simulator command console itself in standalone mode.

=== Asset Service ===

* delete asset <ID> - Delete an asset from the database. Doesn't appear to be implemented.
* dump asset <ID> - Dump an asset to the filesystem.  OpenSimulator 0.7.3 onwards.
* show digest <ID> - Show summary information about an asset. From OpenSimulator 0.7.3 onwards this will be renamed to "show asset"

=== Grid Service ===

* set region flags <Region name> <flags> - Set database flags for region
* show region <Region name> - Show the details of a given region.  This command is renamed to "show region name" in development versions of OpenSimulator.

The following commands currently only exist in development versions of OpenSimulator (post 0.7.3.1).  These are currently found in the "Regions" help section.

* deregister region id <Region UUID> - Deregister a region manually.  This can be helpful if a region was not properly removed due to bad simulator shutdown and the simulator has not since been restarted or its region configuration has been changed.
* show region at <x-coord> <y-coord> - Show details on a region at the given co-ordinate.
* show region name <Region name> - Show details on a region
* show regions - Show details on all regions.  In standalone mode this version of the command is not currently available - the simulator version of "show regions" is used instead, which shows similar information.

=== User Service ===
* create user [first] [last] [passw] [Email] [Primary UUID] [Model} - creates a new user
:or just: create user - and server prompts for all data
:
:If UUID is nul or whitespace a UUID will be generated for you.
:
:Model is the "first lastname" of another user, that user's outfit will be cloned to the new user.
:
* reset user password - This command ''sets'' a new password for a user and directly updates the database. It does not ''reset'' the password to a default or temporary value, as the term might suggest.
* show account <firstname> <lastname> - show account details for the given user name (0.7.2-dev)

=== Login Service ===
* login level <value> - Set the miminim userlevel allowed to login (see [[Userlevel|User Level]]).
* login reset - reset the login level to its default value.
* login text <text to print during the login>
* set user level <firstname> <lastname> <level> - Set UserLevel for the user, which determines whether a user has a god account or can login at all (0.7.2-dev) (see [[Userlevel|User Level]]).

== Details of Terrain Module Commands ==

==== terrain load ====
Loads a terrain from a specified file.

Parameters
* filename (String)
	The file you wish to load from, the file extension determines the loader to be used. Supported extensions include: .r32 (RAW32) .f32 (RAW32) .ter (Terragen) .raw (LL/SL RAW) .jpg (JPEG) .jpeg (JPEG) .bmp (BMP) .png (PNG) .gif (GIF) .tif (TIFF) .tiff (TIFF)

==== terrain load-tile ====
Loads a terrain from a section of a larger file.

Parameters
* filename (String)
	The file you wish to load from, the file extension determines the loader to be used. Supported extensions include: .r32 (RAW32) .f32 (RAW32) .ter (Terragen) .raw (LL/SL RAW) .jpg (JPEG) .jpeg (JPEG) .bmp (BMP) .png (PNG) .gif (GIF) .tif (TIFF) .tiff (TIFF)
* file width (Integer)
	The width of the file in tiles
* file height (Integer)
	The height of the file in tiles
* minimum X tile (Integer)
	The X region coordinate of the first section on the file
* minimum Y tile (Integer)
	The Y region coordinate of the first section on the file

==== terrain save ====
Saves the current heightmap to a specified file.

Parameters
* filename (String)
	The destination filename for your heightmap, the file extension determines the format to save in. Supported extensions include: .r32 (RAW32) .f32 (RAW32) .ter (Terragen) .raw (LL/SL RAW) .jpg (JPEG) .jpeg (JPEG) .bmp (BMP) .png (PNG) .gif (GIF) .tif (TIFF) .tiff (TIFF)

==== terrain fill ====
Fills the current heightmap with a specified value.

Parameters
* value (Double)
	The numeric value of the height you wish to set your region to.

==== terrain elevate ====
Raises the current heightmap by the specified amount.

Parameters
* amount (Double)

==== terrain lower ====
Lowers the current heightmap by the specified amount.

Parameters
* amount (Double)
	The amount of height to remove from the terrain in meters.

==== terrain multiply ====
Multiplies the heightmap by the value specified.

Parameters
* value (Double)
	The value to multiply the heightmap by.

==== terrain bake ====
Saves the current terrain into the regions revert map.

==== terrain revert ====
Loads the revert map terrain into the regions heightmap.

==== terrain newbrushes ====
Enables experimental brushes which replace the standard terrain brushes. WARNING: This is a debug setting and may be removed at any time.

Parameters
* Enabled? (Boolean)
	true / false - Enable new brushes

==== terrain stats ====
Shows some information about the regions heightmap for debugging purposes.

==== terrain effect ====
Runs a specified plugin effect

Parameters
* name (String)
	The plugin effect you wish to run, or 'list' to see all plugins

==== terrain modify ====
Allows area-of-effect and tapering with standard heightmap manipulations.

General command usage:
:''terrain modify <operation> value [<mask>] [-taper=<value2>]''

:Parameters
:* value: base value to use in applying operation
:* mask:
:** -rec=x1,y1,dx[,dy] creates a rectangular mask based at x1,y1
:** -ell=x0,y0,rx[,ry] creates an elliptical mask centred at x0,y0
:* taper:
:** rectangular masks taper as pyramids
:** elliptical masks taper as cones


Terrain Manipulation (fill, min, max)
:* value represents target height (at centre of range)
:* value2 represents target height (at edges of range)

Terrain Movement (raise, lower, noise)
:* value represents a delta amount (at centre of range)
:* value2 represents a delta amount (at edges of range)

Terrain Smoothing (smooth)
:The smoothing operation is somewhat different than the others, as it does not deal with elevation values, but rather with strength values (in the range of 0.01 to 0.99).  The algorithm is simplistic in averaging the values around a point, and is implemented as follows:

:The "strength" parameter specifies how much of the result is from the original value ("strength" * map[x,y]).
:The "taper" parameter specifies how much of the remainder is from the first ring surrounding the point (1.0 - "strength") * "taper". There are 8 elements in the first ring.
:The remaining contribution is made from the second ring surrounding the point.  There are 16 elements in the second ring.
:e.g.
:''terrain modify smooth 0.5 -taper=0.6''
:* the original element will contribute 0.5 * map[x0,y0]
:* each element 1m from the point will contribute ((1-0.5)*0.6)/8 * map[x1,y1]
:* each element 2m from the point will contribute ((1-0.5)*0.4)/16 * map[x2,y2]

Notes:
:The "taper" value may need to be exaggerated due to the integer math used in maps.
:e.g. To create a 512x512 var island:
:''terrain modify min 30 -ell=256,256,240 -taper=-29''

Example:
: https://www.youtube.com/watch?v=pehyqr3H8I0 (dead link)

== Details of Hypergrid Commands ==

For full details and explanations of Hypergrid Commands, see the [http://opensimulator.org/wiki/Installing_and_Running_Hypergrid#Linking_regions_.28Optional.29 Linking Regions] sections of the [http://opensimulator.org/wiki/Installing_and_Running_Hypergrid Installing and Running Hypergrid] page.

'''show hyperlinks''' 

This command will show a list of all hypergrid linked regions.

'''link-region <Xloc> <Yloc> <host> <port> <location-name>'''

* Use Xloc and Yloc that make sense to your world, i.e. close to your regions, but not adjacent.
* replace osl2.nac.uci.edu and 9006 with the domain name / ip address and the port of the region you want to link to

E.g. link-region 8998 8998 osl2.nac.uci.edu 9006 OSGrid Gateway

'''unlink-region <local region name>'''

This command will unlink the specified hypergrid linked region - be sure to use the exact local name as reported by the "show hyperlinks" command.

link-mapping - Link a HyperGrid region. Not sure how this differs from link-mapping.

== Frame Statistics Values ==

The labels of the Frame Statistics values shown by the console command "show stats" are a bit cryptic. Here is a list of the meanings of these values:

* Dilatn - time dilation
* SimFPS - simulator frames per second
* PhyFPS - physics frames per second
* AgntUp - # of agent updates
* RootAg - # of root agents
* ChldAg - # of child agents
* Prims - # of total prims
* AtvPrm - # of active prims
* AtvScr - # of active scripts
* ScrLPS - # of script lines per second
* PktsIn - # of in packets per second
* PktOut - # of out packets per second
* PendDl - # of pending downloads
* PendUl - # of pending uploads
* UnackB - # of unacknowledged bytes
* TotlFt - total frame time
* NetFt - net frame time
* PhysFt - physics frame time
* OthrFt - other frame time
* AgntFt - agent frame time
* ImgsFt - image frame time

  

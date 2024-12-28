# OpenSim.RESTful.API

Eine Idee und Machbarkeitsstudie zur JSON-Kommunikation zwischen PHP und OpenSim für Standalone, Joomla, WordPress (W4OS, jopensim, diva-d2-distribution etc.).

Build erfolgreich mit 0 Warnungen und 0 Fehlern: OpenSim.RESTful.API.dll und OpenSim.RESTful.API.pdb.

`nini` implementiert Konfigurationen über `OpenSim.ini`, `GridCommon.ini` und `Robust.ini`.

## How-To: Erstellen einer allgemeinen Webschnittstelle für OpenSim und Robust

### Überblick

Dieses Projekt zielt darauf ab, eine allgemeine Webschnittstelle zu erstellen, die die Verwaltung und Interaktion mit OpenSim und Robust ermöglicht. 
Diese Schnittstelle soll auf selbst erstellten Webseiten sowie auf beliebten Content-Management-Systemen wie Joomla und WordPress funktionieren.

### Ziele

1. **Allgemeine Schnittstelle**:
   - Entwicklung einer Schnittstelle, die sowohl auf selbst erstellten Webseiten als auch auf Joomla und WordPress genutzt werden kann.
   - Bereitstellung herkömmlicher Webseitendienste.
   - Ermöglichung spezieller Funktionen wie die Benutzerregistrierung und die Verwaltung von Grundstücken oder Regionen.

2. **Verwaltung von OpenSim und Robust**:
   - Einheitliche Verwaltung von Robust und OpenSim über die Webschnittstelle.
   - Zentralisierung der Verwaltungstools, um die Effizienz und Benutzerfreundlichkeit zu erhöhen.

### Schritte zur Umsetzung

#### 1. Einrichtung der OpenSim.RESTful.API

- **Erstellen und Implementieren der API**:
  - Entwickle die API-Controller und -Services, die die benötigten Funktionen wie Benutzerregistrierung, Regionenerstellung und Verwaltung von Grundstücken unterstützen.
  - Beispielstruktur:
    ```
      OpenSim.RESTful.API/
      ├── AssemblyInfo.cs
      ├── Config.ini.example
      ├── create_file_list.bat
      ├── PHP-Integration.md
      ├── prebuild-RESTful.xml
      ├── Program.cs
      ├── README.md
      ├── Struktur.txt
      OpenSim.RESTful.API.Controllers/
      │   ├── OpenSim.RESTful.API.GeneralController.cs
      │   ├── OpenSim.RESTful.API.RobustServiceController.cs
      │   ├── OpenSim.RESTful.API.SimulatorController.cs
      OpenSim.RESTful.API.Helpers/
      │   ├── OpenSim.RESTful.API.CommandParser.cs
      │   ├── OpenSim.RESTful.API.ConfigReader.cs
      │   ├── OpenSim.RESTful.API.ConsoleExtensions.cs
      │   ├── OpenSim.RESTful.API.ConsoleImplementation.cs
      │   ├── OpenSim.RESTful.API.ResponseParser.cs
      OpenSim.RESTful.API.Models/
      │   ├── OpenSim.RESTful.API.Asset.cs
      │   ├── OpenSim.RESTful.API.Region.cs
      │   ├── OpenSim.RESTful.API.User.cs
      OpenSim.RESTful.API.PHP/
      │   ├── Fehlerbehandlung_und_Logging.php
      │   ├── Joomla.md
      │   ├── Kommunikation_von_der_API_zu_PHP.php
      │   ├── Kommunikation_von_PHP_zur_API.php
      │   ├── OpenSimAPIClient.php
      │   ├── Regionen_anzeigen.php
      │   ├── Sicherheit.md
      │   ├── Sicherheit.php
      │   ├── Webhook-Request.php
      │   ├── Webhook.php
      │   ├── WordPress.md
      OpenSim.RESTful.API.Services/
      │   ├── OpenSim.RESTful.API.GeneralService.cs
      │   ├── OpenSim.RESTful.API.IGeneralService.cs
      │   ├── OpenSim.RESTful.API.IRobustService.cs
      │   ├── OpenSim.RESTful.API.ISimulatorService.cs
      │   ├── OpenSim.RESTful.API.RobustService.cs
      │   ├── OpenSim.RESTful.API.SimulatorService.cs         
    ```

#### 2. Integration in Joomla

- **Erstellung einer API-Route**:
  - Erstelle eine neue Route in Joomla, um die API zu erreichen:
    ```php
    class MyComponentController extends JControllerBase
    {
        public function execute()
        {
            $input = JFactory::getApplication()->input;
            $response = $this->getResponse($input->get('action'));
            echo json_encode($response);
            JFactory::getApplication()->close();
        }

        protected function getResponse($action)
        {
            switch ($action) {
                case 'get-server-uptime':
                    return $this->getServerUptime();
                default:
                    return ['error' => 'Unbekannte Aktion'];
            }
        }

        protected function getServerUptime()
        {
            $response = wp_remote_get('https://deine-api-url.com/general');
            return json_decode(wp_remote_retrieve_body($response), true);
        }
    }
    ```

- **Verwendung im Joomla-Template**:
  - Nutze die API in deinem Joomla-Template, um dynamische Inhalte anzuzeigen:
    ```php
    <?php
    $response = wp_remote_get('https://deine-api-url.com/general');
    $data = json_decode($response['body'], true);
    echo '<h1>Server Uptime</h1>';
    echo '<p>' . $data['uptime'] . '</p>';
    ?>
    ```

#### 3. Integration in WordPress

- **Erstellung einer API-Route**:
  - Erstelle eine neue Route in der `functions.php`-Datei von WordPress:
    ```php
    add_action('rest_api_init', function () {
        register_rest_route('open-sim/restful-api/v1', '/general', array(
            'methods' => 'GET',
            'callback' => 'get_general_info',
        ));
    });

    function get_general_info($request) {
        $response = wp_remote_get('https://deine-api-url.com/general');
        return wp_remote_retrieve_body($response);
    }
    ```

- **Verwendung im WordPress-Theme**:
  - Nutze die API in deinem WordPress-Theme, um dynamische Inhalte anzuzeigen:
    ```php
    <?php
    $response = wp_remote_get('https://deine-api-url.com/general');
    $data = json_decode($response['body'], true);
    echo '<h1>Server Uptime</h1>';
    echo '<p>' . $data['uptime'] . '</p>';
    ?>
    ```

### Sicherheit und Authentifizierung

- **Authentifizierung**:
  - Stelle sicher, dass die entsprechenden Header in den API-Anfragen eingefügt werden, wenn eine Authentifizierung erforderlich ist.

### Testen und Debuggen

- **Testen**:
  - Verwende Werkzeuge wie Postman, um die API-Anfragen zu überprüfen und sicherzustellen, dass alles wie erwartet funktioniert.
- **Debuggen**:
  - Teste die Integration gründlich und behebe eventuelle Fehler.

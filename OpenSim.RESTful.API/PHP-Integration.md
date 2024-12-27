# Beispiel für eine PHP-Integration

Du kannst die `file_get_contents`-Funktion in PHP verwenden, um eine POST-Anfrage zu senden und die Antwort zu verarbeiten.

## Beispiel: Benutzer erstellen

```php
<?php
$apiUrl = "http://localhost:5000/api/general/users";
$data = array(
    "firstName" => "John",
    "lastName" => "Doe",
    "password" => "securepassword",
    "email" => "john.doe@example.com"
);

$options = array(
    "http" => array(
        "header" => "Content-Type: application/json\r\n",
        "method" => "POST",
        "content" => json_encode($data),
    ),
);

$context = stream_context_create($options);
$result = file_get_contents($apiUrl, false, $context);
if ($result === FALSE) {
    // Handle error
}

$data = json_decode($result, true);
echo 'User created successfully: ' . $data['result'];
?>
```

## Integration in Bootstrap 5

Du kannst das PHP-Skript einfach in eine Bootstrap 5-Anwendung integrieren, indem du das PHP-Skript in deine Bootstrap-Seiten einfügst.

### Beispiel:

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/5.0.0/css/bootstrap.min.css" rel="stylesheet">
    <title>Bootstrap Example</title>
</head>
<body>
    <div class="container mt-5">
        <?php include 'path/to/your/php/script.php'; ?>
    </div>

    <script src="https://stackpath.bootstrapcdn.com/bootstrap/5.0.0/js/bootstrap.bundle.min.js"></script>
</body>
</html>
```

## Integration in Joomla 5

Erstelle ein Joomla-Modul oder -Plugin, um das PHP-Skript einzubinden und die API zu nutzen.

### Beispiel für ein Joomla-Modul

Erstelle eine Datei `mod_example.php` und füge das PHP-Skript hinzu:

### `mod_example.php`

```php
defined('_JEXEC') or die;

$apiUrl = "http://localhost:5000/api/general/users";
$data = array(
    "firstName" => "John",
    "lastName" => "Doe",
    "password" => "securepassword",
    "email" => "john.doe@example.com"
);

$options = array(
    "http" => array(
        "header" => "Content-Type: application/json\r\n",
        "method" => "POST",
        "content" => json_encode($data),
    ),
);

$context = stream_context_create($options);
$result = file_get_contents($apiUrl, false, $context);
if ($result === FALSE) {
    // Handle error
}

$data = json_decode($result, true);
echo '<p>User created successfully: ' . $data['result'] . '</p>';
```

## Integration in WordPress 6

Erstelle ein WordPress-Plugin, um das PHP-Skript einzubinden und die API zu nutzen.

## Beispiel für ein WordPress-Plugin

Erstelle eine Datei `example-plugin.php` und füge das PHP-Skript hinzu:

### `example-plugin.php`

```php
<?php
/**
 * Plugin Name: Example Plugin
 * Description: Ein Beispiel-Plugin zur Integration der OpenSimulator API.
 */

add_shortcode('create_user', 'create_user_function');

function create_user_function() {
    ob_start();
    
    $apiUrl = "http://localhost:5000/api/general/users";
    $data = array(
        "firstName" => "John",
        "lastName" => "Doe",
        "password" => "securepassword",
        "email" => "john.doe@example.com"
    );

    $options = array(
        "http" => array(
            "header" => "Content-Type: application/json\r\n",
            "method" => "POST",
            "content" => json_encode($data),
        ),
    );

    $context = stream_context_create($options);
    $result = file_get_contents($apiUrl, false, $context);
    if ($result === FALSE) {
        // Handle error
    }

    $data = json_decode($result, true);
    echo '<p>User created successfully: ' . $data['result'] . '</p>';

    return ob_get_clean();
}
```

Aktiviere das Plugin in deiner WordPress-Installation und verwende den Shortcode `[create_user]` in deinen Beiträgen oder Seiten.

Mit diesen Schritten kannst du die in `GeneralService` und `SimulatorService` 
definierten OpenSimulator-Konsolenbefehle in PHP für Bootstrap 5, Joomla 5 und WordPress 6 nutzen, ohne externe Bibliotheken zu verwenden.

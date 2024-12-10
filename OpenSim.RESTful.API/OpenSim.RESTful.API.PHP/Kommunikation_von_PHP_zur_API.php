<?php

// #### **Erklärung**
// 1. **Base URI:** Der API-Basis-URL ist `http://localhost:5000/api/restful/`.
// 2. **POST-Request:** Ein Benutzer wird durch einen POST-Aufruf zu `/robust/users` erstellt.
// 3. **JSON-Daten:** Nutzereingaben werden als JSON gesendet.
// 4. **Ergebnis:** Die Antwort wird decodiert (`json_decode`) und verwendet.

use GuzzleHttp\Client;

require 'vendor/autoload.php'; // Composer-Loader für Guzzle

$client = new Client(['base_uri' => 'http://localhost:5000/api/restful/']);

try {
    $response = $client->post('robust/users', [
        'json' => [
            'FirstName' => 'John',
            'LastName' => 'Doe',
            'Password' => 'securepassword',
            'Email' => 'john.doe@example.com',
        ]
    ]);

    $data = json_decode($response->getBody(), true);
    echo 'User created successfully: ' . $data['result'];
} catch (\Exception $e) {
    echo 'Error: ' . $e->getMessage();
}
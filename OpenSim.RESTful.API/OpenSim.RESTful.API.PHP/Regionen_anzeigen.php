<?php

// #### **Erklärung**
// 1. **GET-Request:** Fordert Daten über Regionen mit `GET /robust/regions` an.
// 2. **Decodieren:** Antwortdaten werden aus JSON ins PHP-Array konvertiert.
// 3. **Verarbeitung:** Regioneninformationen werden durchlaufen und ausgegeben.

use GuzzleHttp\Client;

require 'vendor/autoload.php';

$client = new Client(['base_uri' => 'http://localhost:5000/api/restful/']);

try {
    $response = $client->get('robust/regions');
    $regions = json_decode($response->getBody(), true);

    foreach ($regions['regions'] as $region) {
        echo "Region: {$region['Name']}, UUID: {$region['UUID']}\n";
    }
} catch (\Exception $e) {
    echo 'Error: ' . $e->getMessage();
}
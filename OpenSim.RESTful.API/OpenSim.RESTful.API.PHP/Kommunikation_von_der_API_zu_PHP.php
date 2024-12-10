<?php

// #### **Erklärung**
// 1. **Empfang von Daten:** PHP liest die Anfrage von der API (`php://input`).
// 2. **JSON-Dekodierung:** Wandelt den JSON-Webhook-Payload in ein PHP-Array um.
// 3. **Ereignisbehandlung:** Basierend auf dem `event_type` wird der entsprechende Fall behandelt.

$payload = file_get_contents('php://input');
$data = json_decode($payload, true);

if (isset($data['event_type'])) {
    switch ($data['event_type']) {
        case 'region_updated':
            echo "Region updated: " . $data['region']['name'];
            break;
        case 'user_created':
            echo "New user: " . $data['user']['first_name'] . " " . $data['user']['last_name'];
            break;
        default:
            echo "Unknown event";
    }
} else {
    http_response_code(400);
    echo "Invalid webhook payload";
}
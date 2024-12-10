
# API-Client und Webhook-Validierung

```php
<?php

class OpenSimAPIClient
{
    private $baseUri;
    private $apiToken;

    /**
     * Constructor to initialize the base URI and API token.
     *
     * @param string $baseUri The base URI of the API.
     * @param string $apiToken The API token for authentication.
     */
    public function __construct($baseUri, $apiToken)
    {
        if (empty($baseUri) || empty($apiToken)) {
            throw new InvalidArgumentException('Base URI and API Token must not be empty.');
        }

        $this->baseUri = rtrim($baseUri, '/') . '/';
        $this->apiToken = $apiToken;
    }

    /**
     * Create a new user via the OpenSim RESTful API.
     *
     * @param string $firstName User's first name.
     * @param string $lastName User's last name.
     * @param string $password User's password.
     * @param string $email User's email address.
     */
    public function createUser($firstName, $lastName, $password, $email)
    {
        $url = $this->baseUri . 'robust/users';
        $data = [
            'FirstName' => $firstName,
            'LastName' => $lastName,
            'Password' => $password,
            'Email' => $email,
        ];

        $headers = [
            'Authorization: Bearer ' . $this->apiToken,
            'Content-Type: application/json',
        ];

        $response = $this->makePostRequest($url, $data, $headers);

        if ($response['http_code'] === 200) {
            $responseData = json_decode($response['body'], true);
            if ($responseData['success'] ?? false) {
                echo "User created successfully: " . $responseData['user']['UUID'] . PHP_EOL;
            } else {
                echo "Failed to create user: " . ($responseData['message'] ?? 'Unknown error') . PHP_EOL;
            }
        } else {
            echo "HTTP Error: " . $response['http_code'] . PHP_EOL;
            echo "Response: " . $response['body'] . PHP_EOL;
        }
    }

    /**
     * Makes a POST request using curl.
     *
     * @param string $url The URL to send the POST request to.
     * @param array $data The data to send in the POST body.
     * @param array $headers The headers to include in the request.
     * @return array Response body and HTTP code.
     */
    private function makePostRequest($url, $data, $headers)
    {
        $curl = curl_init();

        curl_setopt($curl, CURLOPT_URL, $url);
        curl_setopt($curl, CURLOPT_POST, true);
        curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));
        curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
        curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);

        $responseBody = curl_exec($curl);
        $httpCode = curl_getinfo($curl, CURLINFO_HTTP_CODE);

        if (curl_errno($curl)) {
            echo "Curl error: " . curl_error($curl) . PHP_EOL;
        }

        curl_close($curl);

        return [
            'body' => $responseBody,
            'http_code' => $httpCode,
        ];
    }
}
```

---

## Webhook-Authentifizierung

Der folgende Code prüft die Authentifizierung eines Webhooks basierend auf einem geheimen Schlüssel (`X-Secret-Key`) und validiert die eingehenden Daten:

```php
<?php

// Webhook validation
$secretKey = 'MY_SECRET_KEY';

// Check if the secret key matches
if ($_SERVER['HTTP_X_SECRET_KEY'] !== $secretKey) {
    http_response_code(403);
    exit('Unauthorized');
}

// Process the incoming Webhook data
$inputData = file_get_contents('php://input');
$data = json_decode($inputData, true);

if (json_last_error() !== JSON_ERROR_NONE) {
    http_response_code(400);
    exit('Invalid JSON payload');
}

// Example processing
echo "Webhook received successfully!" . PHP_EOL;
echo "Data: " . print_r($data, true);
```

---

## Erklärung der Änderungen

1. **Konstruktor-Validierung (`__construct`):**
   - Es wird überprüft, ob `baseUri` und `apiToken` nicht leer sind.
   - Eine `InvalidArgumentException` wird ausgelöst, wenn eines der Argumente fehlt.

2. **Webhook-Authentifizierung:**
   - Der Header `X-Secret-Key` wird überprüft, um sicherzustellen, dass nur autorisierte Quellen die Webhook-Nachricht senden.
   - Falls der Schlüssel nicht übereinstimmt, wird ein HTTP-Statuscode `403 Forbidden` zurückgegeben.

3. **JSON-Payload-Verarbeitung:**
   - Die eingehenden Daten werden mit `file_get_contents('php://input')` gelesen.
   - `json_decode` wird verwendet, um die JSON-Daten zu verarbeiten.
   - Fehlerhafte JSON-Daten führen zu einem `400 Bad Request`.

---

## Beispiel-Aufruf

### Webhook-Request in PHP

Ein Webhook-Aufruf könnte mit folgendem PHP-Skript simuliert werden:

```php
<?php

$webhookUrl = 'http://localhost/webhook.php';
$data = ['event' => 'user.created', 'userId' => '12345'];

$headers = [
    'Content-Type: application/json',
    'X-Secret-Key: MY_SECRET_KEY',
];

$curl = curl_init();
curl_setopt($curl, CURLOPT_URL, $webhookUrl);
curl_setopt($curl, CURLOPT_POST, true);
curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));
curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);
curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);

$response = curl_exec($curl);
$httpCode = curl_getinfo($curl, CURLINFO_HTTP_CODE);

curl_close($curl);

echo "Response: " . $response . PHP_EOL;
echo "HTTP Code: " . $httpCode . PHP_EOL;
```

## Testen

1. Speichere die API-Klasse in `OpenSimAPIClient.php`.
2. Speichere die Webhook-Validierung in `webhook.php`.
3. Verwende das Webhook-Testskript, um die Webhook-Verarbeitung zu simulieren.

Dieses Setup stellt sicher, dass die Authentifizierung korrekt funktioniert und bietet robuste Fehlerbehandlung für die API und den Webhook

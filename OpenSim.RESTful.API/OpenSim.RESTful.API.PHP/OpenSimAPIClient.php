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
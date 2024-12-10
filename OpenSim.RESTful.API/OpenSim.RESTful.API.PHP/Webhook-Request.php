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
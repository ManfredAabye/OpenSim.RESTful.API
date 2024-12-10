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
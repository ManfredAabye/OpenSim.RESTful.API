<?php

//### **Authentifizierung**
//- **API-Token:** Stelle sicher, dass die PHP-Clientanfragen ein API-Token im Header senden:

  $response = $client->post('robust/users', [
      'headers' => ['Authorization' => 'Bearer YOUR_API_TOKEN'],
      'json' => [...],
  ]);


//- **Webhook-Authentifizierung:** Lass die API einen geheimen Schlüssel im Webhook-Payload senden. PHP validiert diesen:

  if ($_SERVER['HTTP_X_SECRET_KEY'] !== 'MY_SECRET_KEY') {
      http_response_code(403);
      exit('Unauthorized');
  }
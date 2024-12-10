<?php

//### **API-Antworten validieren**
//Prüfe stets den Statuscode der API-Antwort:

if ($response->getStatusCode() !== 200) {
    throw new Exception('API call failed: ' . $response->getReasonPhrase());
}


//### **Fehlerlog erstellen**
//Nutze ein Logging-Framework wie **Monolog** oder schreibe Logs in eine Datei:

file_put_contents('error.log', $e->getMessage(), FILE_APPEND);
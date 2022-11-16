# Informationen
Ein Web API für eine imaginäre Skiservice-Firma (Jetstream Service), diese Firma hat bereits eine Online Präsenz, braucht aber noch ein Web API.  
Dieses Web API brauchen Sie für die Aufnahme von Registrationen, welche dann in einer Datenbank gespeichert werden.  
Das Web API muss auch eine Authentifikation bieten, welche Admins erlaubt Registrationen zu modifizieren und auszulesen.  
Zusätzlich muss die Datenbank aus mehreren Relationalen Datenbanken bestehen.

## Durchsetzung

Dieses Projekt habe ich mit C# durchgesetzt, für die Datenbankerstellung habe ich ein Code-First Prinzip und einen TSQL Skript verwendet.  
Für die Auslesung der Datenbank habe ich das Entity Framework verwendet.  
Zuletzt habe ich für die Durchsetzung des Web APIs Services und Dependency Injection (DI) verwendet.  
Für die Authentifikation von Admins habe ich ein JWT Token, welches einen Tag gültig ist, verwendet.  

## Mehr Informationen

Wenn Sie mehr Informationen zu diesem Projekt wollen, können Sie die Projektdokumentation nach IPERKA im GitHub nachlesen.  
Wenn Sie mehr Informationen zu diesem Web API wollen, können Sie die Swagger Dokumentation durch Visual Studio nachlesen.  
Um das Web API Projekt zu debuggen, können Sie die Postman Collection verwenden.

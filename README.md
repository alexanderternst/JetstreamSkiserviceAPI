# Informationen
Ein Web API für eine imaginäre Skiservice Firma (Jetstream Service), diese Firma hat bereits eine Online Präsenz, braucht aber noch ein Web API.  
Dieses Web API brauchen Sie für die aufnahme von Registrationen, welche dann in einer Datenbank gespeichert werden.  
Das Web API muss auch eine Authentifikation bieten welche Admins erlaubt Registrationen zu modifizieren und auszulesen.  
Zusätzlich musss die Datenbank aus mehreren Relationalen Datenbanken bestehen.

## Durchsetzung

Dieses Projekt habe ich mit C# durchgesetzt, für die Datenbankerstellung habe ich ein Code-First Prinzip und einen TSQL Skript verwendet.  
Für die auslesung der Datenbank habe ich das Entity Framework verwendet.  
Zuletzt habe ich für die durchsetzung des Web APIs Services und Dependency Injection (DI) verwendet.  
Für die Authentifikations von Admins habe ich ein JWT Token welches einen Tag gültig ist verwendet.  

## Mehr Informationen

Wenn Sie mehr Informationen zu diesem Projekt wollen können Sie die Projektdokumentation nach IPERKA im GitHub nachsehen.

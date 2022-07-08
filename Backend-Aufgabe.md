# Code-Challenge

## Voraussetzungen

- .NET6-SDK

## Kontext

Das Projekt beeinhaltet eine REST-HTTP-Schnittstelle, die Informationen über Veranstaltungen bereitstellt.
Es gibt zwei Endpunkte:

- GET /events/ - Liefert eine Liste an Veranstaltungen.
- GET /events/:id - Liefert die Informationen eines bestimmten Events.

Zu einer jeden Veranstaltung liegen folgende Informationen vor:

Information | Beschreibung
----------- | ------------ 
ID          | Kennung der Veranstaltung  
Jahr        | Jahr der Veranstaltung 
Name        | Name der Veranstaltung 
StartDate   | Startdatum der Veranstaltung 
EndDate     | Enddatum der Veranstaltung 
Type        | Typ der Veranstaltung (mögliche Werte: OnSite, Online, Hybrid) 

## Aufgabenstellung

### 1. Veranstaltungs-Statistiken

Der Endpunkt zum Abrufen einer Veranstaltung soll um die Ermittlung und Ausgaben von Statistiken der jeweiligen Veranstaltung erweitert werden, hierbei gilt es eine sinnvolle Struktur für die Integration in das bestehende Schnittstellen-Schema zu wählen.

Je nach Event-Typ müssen unterschiedliche Datenquellen für den Abruf der Statistiken verwendet werden. Sollte es sich um eine hybride Veranstaltung handeln, müssen beide Datenquellen herangezogen werden.

Datenquelle                             | URL
--------------------------------------- | ------------------------ 
Statistiken für Online-Veranstaltungen  | GET https://onlineevent-statistics.azurewebsites.net/api/statistics/:eventId
Statistiken für Vor-Ort-Veranstaltungen | GET https://onsite-eventstatistics.azurewebsites.net/api/:id

### 2. Prozess zum Veranstaltungsabschluss

### Prozessbeschreibung

Nach Ende einer jeden Veranstaltung soll ein sogenannter Veranstaltungsabschluss durchgeführt werden können. 

Bei einem Veranstaltungsabschluss werden nicht mehr benötigte Daten im System bereinigt werden. Welche Daten bereingt werden sollen, muss bei der Planung des Prozesses festgelegt werden. Folgende Daten-Typen können für die Auswahl berücksichtigt werden:

- unbenutzte Tickets
- unbenutzte Gutscheine

Nach der Durchführung des Veranstaltungsabschlusses soll für jeden Daten-Typ die Information bereitgestellt werden, wie viele Datensätze betroffen sind.

Die Durchführung des Prozesses erfolgt asynchron zu dem geplanten Ausführungszeitpunkt. Ein Veranstaltungsabschluss darf erst nach dem Ende der jeweiligen Veranstaltung geplant werden.

### Schnittstellen-Anforderung

Über die Schnittstelle soll der Prozess zum Veranstaltungsabschluss angestoßen werden können und jederzeit den aktuellen den Status des Prozesses abgerufen werden können. Außerdem sollen den Schnittstellen-Konsumenten die beschriebenen Voraussetzungen für die Planung und Durchführung des Prozesses bereitgestellt werden.

*Hinweis: Die Schnitts
telle soll erstmal eine Mock-Implementierung des Prozesses verwenden, die zusätzlich geschaffen werden muss*
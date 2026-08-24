# Rohstoff-Retter

Rohstoff-Retter ist ein Serious Game für Kinder zu Mülltrennung, entstanden im Rahmen eines
Forschungsprojekts der Uni. Der Spieler strandet auf einer Insel auf der er 
"Shelly" der Schildkröte begegnet. "Shelly" braucht Hilfe, die Insel vom Müll zu befreien.
Das Haupt Gameplay besteht daraus, durch Drag and Drop in einer Art Wimmelbild den richtigen Müll
in die Mülltonne zu sortieren. Beim der Gestaltung des Spiels sollten die Heuristiken von Nielsen 
angewendet werden, bzw. wurden diese als Evaluationsgrundlage genutzt. 

## Demo
xxx

## Nutzung von KI

Unsere Dozentin hat uns den Einsatz von Ki grundsätzlich erlaubt aber mit Grenzen.
Simpel gesagt: - alles von Ki coden zu lassen war tabu - 
KI solle als Hilfsmittel eingesetzt werden, zum Beispiel für Syntaxerklärungen oder fürs Degugging.
Daran habe ich mich gehalten. Des weiteren habe ich die Aufgabe als Chance gesehen meine 
Programmier Kenntnisse etwas zu erweitern. Dadurch bestand bei mir auch ein intrinsiches Motiv, 
nicht alles agentisch machen zu lassen.

## Funktionen

- Drag and Drop
- Verschiedene Arten von Feedback (visuelles und auditives)
- Monologe
- Spielprogression 

## Dateien Struktur mit grober Aufgabenbeschreibung

- DialogManager: Steuert Dialoge, Teile des UI und den Übergang zwischen Dialog, Gameplay und Feedback
- DragAndDrop: Kernlogik des Gameplays, ermöglicht Drag-and-Drop, Müllzuordnung, direktes Feedback und Spielfortschritt
- MüllTonne: Enthält Funktionen für Zustand und Verhalten der Mülltonnen
- GameManager: Verwaltet Teile des Spielablaufs, beinhaltet Variablen in denen Game Elemente wie UI gespeichert werden
- SoundManager: Verwaltet Audioquellen und enthält Sound Funktionen


## Benutzte Sprachen

C#

## Was ich gelernt habe

- C# Kenntnisse
- Usability Heuristiken von Nielsen anwenden
- Aufbauen von Verbindungen zwischen Scripten
- "Sinnvolle" Funktionsverlagerung auf verschiedene Scripte
- Programme mit Abläufen bauen (A passiert, dann passiert B... Wenn C, dann D...)
- Umgang mit Unity Editor
- 2D Spiele erstellen mit Unity



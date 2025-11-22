# 📘 Excel Double Entry System

Das **Excel Double Entry System** ist eine vollständig lokal ausgeführte Lern- und Übungsumgebung für die doppelte Buchführung.  
Es kombiniert übersichtliche Tabellen, T-Konten, automatische Berechnungen sowie ein optionales Update-System auf Basis einer externen C#-Anwendung.

Die Datei ist ideal für Ausbildung, Studium und Selbststudium geeignet.

---

# ✨ Funktionen

## ✔ Strukturierte T-Konten
Vollständig vorbereitete T-Konten zur Verbuchung aller Buchungssätze.

## ✔ Automatische Berechnungen
- Summen und Salden
- Bilanzbereiche
- Aufwands- und Ertragskonten
- Automatische Journal-Auswertung

## ✔ Übersichtliche Tabellenstruktur
Journal, Bilanz, Kontenübersicht sowie Übungsblätter sind klar getrennt.

## ✔ Integrierter VBA-Code
Unterstützt:
- Navigation
- Komfortfunktionen
- Automatisches Starten des Updaters

---

# 🚀 Automatisches Update-System (optional)

Neben der Excel-Datei gibt es eine **C#-Konsolenanwendung**, die:

- GitHub nach neuen Releases prüft  
- das neueste Release herunterlädt  
- die vorhandene Excel-Datei ersetzt  
- anschließend automatisch wieder startet  

### Benötigte Dateien im Ordner
Damit der Updater funktioniert, müssen alle Dateien im selben Ordner liegen:

```
ExcelDoubleEntrySystem.xlsx
Updater.exe
appsettings.json
weitere benötigte DLLs
```

---

# 💾 Installation (lokal, nicht Cloud-kompatibel)

⚠ **WICHTIG:**  
Das System funktioniert **nicht**, wenn die Excel-Datei in einem Cloud-Ordner gespeichert wird, z. B.:

- OneDrive
- SharePoint
- Google Drive
- Dropbox
- iCloud

Cloud-Dienste blockieren oder synchronisieren Dateien und verhindern so das korrekte Arbeiten des Updaters.

---

# 📥 Installationsanleitung

## 1️⃣ Release herunterladen
Unter „Releases“ findest du:

### **Erstinstallation:**
Enthält:
- Excel-Datei  
- Updater  
- alle benötigten JSON-/DLL-Dateien  

### **Weitere Releases:**
Enthalten nur die aktualisierte Excel-Datei.

## 2️⃣ Dateien lokal ablegen
Beispiel:

```
C:\Programme\ExcelDoubleEntrySystem\
```

## 3️⃣ Excel starten
Öffne:

```
ExcelDoubleEntrySystem.xlsx
```

Updates können später über VBA gestartet werden.

---

# 🔧 Nutzung des Updaters

Der Updater zeigt:

- Fortschrittsbalken  
- Prüfung auf neue Releases  
- Download und Ersetzen der alten Datei  
- automatischen Neustart der Excel-Datei  

Wenn **kein Update** verfügbar ist:
- die Excel-Datei wird normal geöffnet
- keine Dateien werden verändert

Optional wird das Backup nach erfolgreichem Update gelöscht.

---

# 🗂 Repository-Inhalte

- Excel-Datei  
- C#-Updater  
- VBA-Code  
- Quellcode des Updaters  
- Beispielkonfiguration  
- README  
- GitHub Releases  

---

# 📜 Lizenz

Dieses Projekt steht unter:

## **Creative Commons Attribution-NoDerivatives 4.0 (CC BY-ND 4.0)**

Du darfst:
- die Datei weitergeben  
- sie kommerziell nutzen  

Aber:
- keine veränderte Version verbreiten  
- Urheber nennen  
- Lizenz verlinken  

Lizenztext:  
https://creativecommons.org/licenses/by-nd/4.0/legalcode

---

# 📨 Kontakt & Feedback

Fragen, Feedback oder Ideen?  
Einfach über **GitHub-Issues** melden.

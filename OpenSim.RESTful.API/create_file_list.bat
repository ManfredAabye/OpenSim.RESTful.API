@echo off
setlocal enabledelayedexpansion

:: Ausgangsverzeichnis setzen (Anpassen nach Bedarf)
set "base_dir=OpenSim.RESTful.API"

:: Ausgabe Datei setzen
set "output_file=file_list.txt"

:: Rekursive Funktion zum Auflisten der Dateien und Verzeichnisse
call :list_files "%base_dir%" 0 > "%output_file%"
goto :eof

:list_files
set "dir_path=%~1"
set "indent_level=%~2"

:: Leerzeichen für Einrückungen basierend auf der Ebene erstellen
set "indent="
for /L %%i in (0, 1, %indent_level%) do (
    set "indent=!indent!│   "
)

:: Verzeichnisname zur Ausgabe hinzufügen
if %indent_level% gtr 0 (
    echo !indent!├── %~nx1
) else (
    echo %~nx1/
)

:: Durch alle Dateien und Unterverzeichnisse im aktuellen Verzeichnis iterieren
for /f "delims=" %%i in ('dir /b /a-d "%dir_path%"') do (
    echo !indent!│   ├── %%i
)

for /d %%d in ("%dir_path%\*") do (
    call :list_files "%%d" %indent_level% + 1
)

goto :eof

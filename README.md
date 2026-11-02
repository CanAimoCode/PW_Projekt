# Cyberware z Cyberpunka — katalog korporacji i implantów

Projekt zaliczeniowy z Programowania Wizualnego. Temat: cyberware.
**Producer = Korporacja**, **produkt = Implant** (`IImplant`, enum `ImplantType`).
Ceny w eurodolarach (`€$`).

## Struktura

```
Interfaces/   IProducer, IImplant, IDAO, ImplantType
DAOMock/      BO/Producer, BO/Implant, DAO           (baza 1: Arasaka, Militech, ...)
DAOMock2/     BO/Producer, BO/Implant, DAO           (baza 2: Zetatech, Dynalar, ...)
BLC/          singleton + dynamiczne ładowanie DLL   (System.Reflection)
App/          aplikacja konsolowa + App.config
```


## Uruchomienie

```powershell
dotnet build PW_Projekt.sln

# App NIE referencjonuje bibliotek DAO — kopiujemy DLL-e ręcznie do katalogu wykonywalnego
Copy-Item DAOMock/bin/Debug/net8.0/DAOMock.dll App/bin/Debug/net8.0/
Copy-Item DAOMock2/bin/Debug/net8.0/DAOMock2.dll App/bin/Debug/net8.0/

dotnet run --project App/App.csproj

# albo bezpośrednio z katalogu wykonywalnego:
cd App/bin/Debug/net8.0
./App.exe
```

Nazwa `DAOMock.dll` z konfiguracji jest ścieżką względną i nie jest doklejana do katalogu
aplikacji. `dotnet run` startuje z katalogu wyjściowego dzięki `RunWorkingDirectory`
w `App.csproj`; `App.exe` uruchamiaj z katalogu, w którym leży.

## Przełączanie bazy danych

W `App/App.config` (a po kompilacji w `App/bin/Debug/net8.0/App.dll.config`):

```xml
<add key="daoLibrary" value="DAOMock.dll" />
```

Aby zmienić bibliotekę **bez rekompilacji**, edytuj plik w katalogu wykonywalnym:

```powershell
cd App/bin/Debug/net8.0
(Get-Content App.dll.config) -replace 'DAOMock2?\.dll', 'DAOMock2.dll' | Set-Content App.dll.config
./App.exe
```

Zmiana `App/App.config` w IDE nie trafi do `App.dll.config` w katalogu wykonywalnym
bez ponownej kompilacji. Można też podać w konfiguracji ścieżkę bezwzględną do DLL.

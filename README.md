# Cyberware z Cyberpunka — katalog korporacji i implantów

Projekt zaliczeniowy z Programowania Wizualnego. Temat: cyberware.
**Producer = Korporacja**, **Product = Implant** (enum `ImplantType`).
Ceny w eurodolarach (`€$`).

## Struktura

```
Interfaces/   IProducer, IProduct, IDAO, ImplantType
DAOMock/      BO/Producer, BO/Implant, DAO           (baza 1: Arasaka, Militech, ...)
DAOMock2/     BO/Producer, BO/Implant, DAO           (baza 2: Zetatech, Dynalar, ...)
BLC/          singleton + dynamiczne ładowanie DLL   (System.Reflection)
App/          aplikacja konsolowa + App.config
Tests/        testy xUnit
```


## Uruchomienie

```powershell
dotnet build PW_Projekt.sln
dotnet run --project App/App.csproj
dotnet test PW_Projekt.sln
```

## Przełączanie bazy danych

W `App/App.config`:

```xml
<add key="daoLibrary" value="DAOMock.dll" />
```

```powershell
cd App/bin/Debug/net8.0
(Get-Content App.dll.config) -replace 'DAOMock2?\.dll', 'DAOMock2.dll' | Set-Content App.dll.config
./App.exe
```

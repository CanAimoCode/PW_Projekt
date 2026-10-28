# Cyberware z Cyberpunka — katalog korporacji i implantów

Projekt zaliczeniowy z Programowania Wizualnego (laboratoria 1–3). Temat: cyberware.
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

`App` nie referencjonuje bibliotek DAO w czasie kompilacji — ładuje DLL wskazane
w `App.config` (`System.Reflection`, `Assembly.UnsafeLoadFrom`).

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

Zmiana na `DAOMock2.dll` — bez rekompilacji — wystarczy w pliku `App.dll.config`
w katalogu wyjściowym aplikacji (DLL-e obu baz są tam kopiowane przy buildzie):

```powershell
cd App/bin/Debug/net8.0
(Get-Content App.dll.config) -replace 'DAOMock2?\.dll', 'DAOMock2.dll' | Set-Content App.dll.config
./App.exe
```

## Mapowanie na laboratoria

| Laboratorium | Realizacja |
|---|---|
| 1 zad. 1–3, 6 | solution + biblioteki + referencje, `StartupObject`, klasy BO katalogu |
| 2 zad. 1–9 | enum, `BO/`, `DAO`, druga baza, `Interfaces`, `IEnumerable` |
| 3 zad. 1–5 | kolekcje generyczne, `App.config`, refleksja, `BLC`, singleton |
| 1 zad. 4–5, 3 zad. 6 | poza zakresem projektu (ćwiczenia demonstracyjne) |

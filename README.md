# BlazorWebAppMovies

## Build

dotnet build

## Update database

```bash
dotnet tool install --global dotnet-ef
dotnet ef --project BlazorWebAppMovies.BusinessLogic --startup-project BlazorWebAppMovies database update
```

## Run

```bash
dotnet run --project BlazorWebAppMovies
```

## Test

### terminal window 1

```bash
dotnet tool install --global PowerShell
cd BlazorWebAppMovies.AcceptanceTests
pwsh ./bin/Debug/net8.0/playwright.ps1 install --with-deps
cd ..
dotnet run --environment Test --project BlazorWebAppMovies --urls http://localhost:8765
```

### terminal window 2

```bash
BASE_URL=http://localhost:8765 HEADED=1 dotnet test
```

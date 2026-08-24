# Agent Setup Guide for keep-the-progress

## Local Conventions & Workflows

*   **Build Flow:** Always `dotnet restore` before building/testing the target project.
*   **Build Command:** Use `dotnet build --project <path_to_csproj>` or target the solution via `dotnet build`.
*   **Test Command:** Use `dotnet test` to run tests. No existing general test runner commands are present, so specify the full command when needed.
*   **Development Cycle:** Follow the order: (1) Make changes -> (2) `dotnet build` -> (3) `dotnet test` -> (4) `dotnet run` (if necessary).
*   **Linting/Typechecking:** Before committing changes, explicitly run `dotnet build` and check for any non-standard warnings/errors.

## Architecture Boundaries

*   **Monorepo Structure:** The solution uses a monorepo approach across three main areas:
    *   **`KTP.Shared/`**: Core shared code, common UI components, and interfaces (e.g., `IFormFactor.cs`).
    *   **`KTP.Web.Client/`**: Blazor WebAssembly SPA client application.
    *   **`KTP.Mobile/`**: The main .NET MAUI project/launcher.
*   **Entry Point:** The application lifecycle starts in the `MauiProgram.cs` found in `KTP.Mobile/`.
*   **Navigation:** Use `maui-shell-navigation` (via `Shell.Current.GoToAsync`) for all cross-page navigation.
*   **Data Flow:** Shared services are consumed via constructor injection in `MauiProgram.cs` (use `maui-dependency-injection`).

## Framework Quirks & Gotchas

*   **MAUI Initialization:** The environment requires explicit `dotnet restore` at the start of any session before building or testing.
*   **BLazor Integration:** Blazor components are rendered on multiple platforms and rely on `wwwroot` assets. Shared Razor pages use `Shared/Pages` and are routed through `Routes.razor`.
*   **State Management:** Use the `maui-app-lifecycle` skill for handling state-saving logic when the app goes to the background.
*   **Styling:** The primary mechanism for theming is `AppThemeBinding` and `ResourceDictionary` (see `maui-theming` skill).

## Tools:

*   **Lint/Check:** No dedicated linting commands were found. Rely on standard `dotnet build` output for compile-time checks.

**Recommendation:** When encountering build or test issues, start by running `dotnet restore` in the repository root.
A potential next step is confirming the exact test framework (NUnit/MSTest) and preferred CI/CD pipeline for accurate testing instructions.
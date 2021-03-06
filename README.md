# CEII Api v2

## Requirements

You need to have installed:
- [WSL2](https://aka.ms/wsl2) with Ubuntu 20.04 (Ubuntu downloaded from MS Store)
- [.NET 6](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2110-) SDK and ASP.NET Core Runtime for WSL2
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) SDK and ASP.NET Core Runtime for Windows
- [EF Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) for WSL2
- [EF Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools) for Windows
- [Docker](https://docs.docker.com/desktop/windows/wsl/)
- Any .NET IDE or Code Editor (preferably [Rider](https://www.jetbrains.com/rider/))

## Installation Steps
- Clone project and fetch develop branch
- If you're using IDE, then run project with it, else check [commands section](#commands-to-run-solution-in-code-editor)

## Commands

### General commands
- Check template names to generate project
  ```bash
  dotnet new --list
  ```

### Commands to run solution in Code Editor
These are **not needed** when using .NET IDE. Run them in WSL2 bash.

- Run project in watch mode (from root directory)
    ```bash
      dotnet watch run --startup-project src/Ceii.Api.Core
   ```
- Generate new project inside solution
  - If project is for testing
    ```bash
    dotnet new xunit <project-name> --output-dir tests/<project-name>
    
    dotnet sln add tests/<project-name>
    ```
  - If project is for source code (depends of template)
    ```bash
    dotnet new <short-name> <project-name> --output-dir src/<project-name>

    dotnet sln add src/<project-name>
    ```

### Commands for EF Core
EF Core commands need flags in order to work properly, if you're inside root directory, then you always
have to add `--project src/Ceii.Api.Data` flag at the end. You can run this in WSL2 or Powershell.

- Create migration
  ```bash
  dotnet ef core migrations add <migration-name> --startup-project src/Ceii.Api.Core --project src/Ceii.Api.Data
  ```
- Update database (run pending migrations)
  ```bash
  dotnet ef core database update --startup-project src/Ceii.Api.Core --project src/Ceii.Api.Data
  ```

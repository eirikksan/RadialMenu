# .NET 8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade RadialMenu\RadialMenu.csproj
4. Upgrade RadialMenuDemo\RadialMenuDemo.csproj

## Settings

This section contains settings and data used by execution steps.

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### RadialMenu\RadialMenu.csproj modifications

Project properties changes:
- Convert project to SDK-style format
- Target frameworks should be changed from `net48` to `net48;net8.0-windows` to maintain .NET Framework 4.8 support while adding .NET 8.0

#### RadialMenuDemo\RadialMenuDemo.csproj modifications

Project properties changes:
- Convert project to SDK-style format  
- Target frameworks should be changed from `net48` to `net48;net8.0-windows` to maintain .NET Framework 4.8 support while adding .NET 8.0
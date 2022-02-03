### ejector
##### Windows command-line utility for ejecting removable drives
###### C# - .NET 6.0

------------

Build to single executable with:

`dotnet publish -r win-x64 --self-contained false`

------------

Command-line options

`-d {DRIVELETTER}` : Specifies drive letter to eject.

`-v`: Verbose, debug output

`--ls`: Lists removable drives

`-h`: Help

------------

Tested on Windows 10 build 21H2

------------

Depends on:

[System.CommandLine](https://github.com/dotnet/command-line-api "System.CommandLine")

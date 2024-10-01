Restore dotnet tool:
    `dotnet tool restore (from "Pds" directory)`

Actual version of dotnet-ef palced:
    `/Pds/.config/dotnet-tools.json`

Add migration: 
    `dotnet ef migrations add Initial --project Pds.Data --startup-project Pds.Api`
    
Update database:
    `dotnet ef database update --project Pds.Data --startup-project Pds.Api`
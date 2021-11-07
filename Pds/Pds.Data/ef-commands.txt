Add migration: 
    dotnet ef migrations add Initial --project Pds.Data --startup-project Pds.Api
    
Update database:
    dotnet ef database update --project Pds.Data --startup-project Pds.Api

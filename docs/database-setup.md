# Database Setup
0. Install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other SQL-native database (`Azure SQL Edge` for ARM or Apple Silicon)
1. Create a database named `pds` (or any other name you prefer)
2. Update the database connection string `DefaultConnection` in the `Pds\Pds.Api\appsettings.json` file

The database migration and data initialization will occur automatically when the backend (Pds.Api) is first launched.
If you want to manually run the database migration, open a console in the project's root folder and run the "Update database" command from the `docs\ef-commands.cmd` file
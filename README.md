[![License](https://img.shields.io/github/license/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/blob/develop/LICENSE)
[![Stars](https://img.shields.io/github/stars/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/stargazers)
[![Issues](https://img.shields.io/github/issues/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/issues)

[![Deploy apps to Production](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml/badge.svg?branch=main)](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml)

**Bloggers CMS** is a content management system specifically developed for bloggers' needs.  
It is powered by **.NET 8** and **Blazor WebAssembly** technologies.

The CMS allows you to keep track of:
- Content & content participants
- Clients
- Income and expenses
- Gifts and contests

Additional features:
- Authentication system based on Auth0 (can be disabled)
- Flexible internal settings system
- Flexible entity filters
- Ability to manage multiple _Brands_ within a single interface
   - "Brand" is an entity to which content, content participants, income, and expenses are linked. This can be a separate YouTube channel, blogger, project, company, etc.
- Minor recommendation capabilities

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/1.png" title="Dashboard" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/2.png" title="Content List" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/3.png" title="Settings" width="800" />

## Install and run
### Without Docker
1. [Install and configure the SQL database](https://github.com/it-beard/bloggers-cms/tree/develop/docs/database-setup.md)
2. Disable Auth0 authentication
   - By default, the CMS includes [Auth0 authentication](https://auth0.com/), which requires additional [configuration](https://github.com/it-beard/bloggers-cms/tree/develop/docs/auth0.md).
   - To disable Auth0 authentication, set the parameter `Auth0:Enabled` to `false` in the following files:
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` - disables authentication on the frontend side
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` - disables authentication on the local frontend instance (localhost)
       -  `bloggers-cms/Pds/Pds.Api/appsettings.json` - disables authentication on the backend side
3. Configure the CMS according to the description in the "**Settings**" section.
4. Run the `Pds.Api` and `Pds.Web` projects ([how to run .NET application](https://github.com/it-beard/bloggers-cms/tree/develop/docs/run.md))
       
_The database migration will occur automatically when you first run the `Pds.Api` project._

### With Docker

To run the application in Docker, simply enter the command:
`docker compose -f "./Pds/.run/docker-compose.yaml" up -d`

#### Features of the Application in Docker:

1. By default, [Auth0 authentication](https://auth0.com/) is **disabled**.
2. Data from the database is stored in a dedicated volume, which allows preserving state even after restarting/recreating containers.
3. There is no TLS/SSL support; therefore, everything works over HTTP.
4. The application is running in **Development** mode.
5. The frontend is available at [http://localhost:5000](http://localhost:5000).
6. Blazor is hosted using [NGINX](https://www.nginx.com/).

## Settings

### Settings for Pds.Web 
This is the frontend of Bloggers CMS, running on Blazor WebAssembly.

The main settings are located in the files `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` (used in production) and `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` (used when running locally):
   - The `Auth0` section contains [Auth0](https://auth0.com) authentication settings.
   - The `BackendApi:Url` parameter contains the URL of the deployed instance of `Pds.Api`.

### Settings for Pds.Api 
This is the backend API of Bloggers CMS, running on .NET.

The project settings are located in the file `bloggers-cms/Pds/Pds.Api/appsettings.json`:
   - The `Logging` section contains logging settings. Default values usually do not require changes.
   - The `AllowedOrigins` section contains a list of root URLs of allowed frontend applications. Add the root link to your deployed instance of `Pds.Web` here.
   - The `Auth0` section contains [Auth0](https://auth0.com) authentication settings.
   - The `ConnectionStrings:DefaultConnection` parameter contains the connection string to the database.

## Useful Links

- [Setting for authentication via Auth0](https://github.com/it-beard/bloggers-cms/tree/main/develop/auth0.md)
- [Database setup](https://github.com/it-beard/bloggers-cms/tree/develop/docs/database-setup.md)
- [Contributing guidelines](https://github.com/it-beard/bloggers-cms/tree/develop/docs/code-guidelines.md)
- [All project's docs](https://github.com/it-beard/bloggers-cms/tree/develop/docs/) 
- For all questions, use [discussions](https://github.com/it-beard/bloggers-cms/discussions)

## License

Apache License 2.0, see [LICENSE](LICENSE) for details.
## Code Guidelines and Naming Conventions
- We use UUID (GUID) as unique identifiers for entities (in code and on the database side)
  - [Online Guid Generator](https://www.guidgenerator.com/)
- In case of disputes, we follow the official Naming Conventions: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines
- Always use the full if notation with curly braces
```
if (true)
{
   body
}
```
- Asynchronous methods should have the `Async` postfix regardless of the access modifier
- All Blazor components with routes (pages) should inherit from `BasePageComponent`
- Authorization for Blazor pages is implicitly inherited from `BasePageComponent`, so the `[Authorize]` attribute is not needed in derived classes

## Git Conventions
When working, we create our branch from `develop` and name it as follows:   
`{github_username}` + `/{task_type}` + `/{task_number}`   

**Examples:** 
- `itbeard/feature/17`
- `itbeard/bug/22`

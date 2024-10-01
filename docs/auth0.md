## Setting up your own application for authorization

1. Register at [Auth0](https://auth0.com/)
2. Create an `Application` of type `Single Page Application`
* Note down the `Domain` and `Client ID` on the `Settings` page
* In the `Allowed Callback URLs` field, enter `https://{your_frontend_domain}/authentication/login-callback`.
This value tells Auth0 which URL to call back after users authenticate.
* In the `Allowed Logout URLs` field, enter `https://{your_frontend_domain}`.
This value tells Auth0 which URL users should be redirected to after they logout.
* Update the contents of the file `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json`:
   * `Auth0:Authority` = `Domain` from Auth0
   * `Auth0:ClientId` = `Client ID` from Auth0
3. In Auth0, create an `API` (choose an `Identifier` as you like and remember it, you'll need it later)
* Update the contents of the file `bloggers-cms/Pds/Pds.Api/appsettings.json`:
   * `Auth0:Authority` = `Domain` from Auth0
   * `Auth0:ApiIdentifier` = `Identifier` of the created API in Auth0
   * `Auth0:AllowedAppId` = same as `Auth0:ClientId` from the file `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` (see above)

4. In Auth0, delete the database in the `Authentication - Database` tab or remove the connection of your `Application` to this database to allow login only through Google. You can manage login methods in the `Connections` tab of your application in Auth0

5. In Auth0, in the `Tenant` settings, set the `Default Audience` value to the `Identifier` of the API created above

6. Add a `Rule` that explicitly specifies which emails have access to authorization
* Go to the `Auth Pipeline - Rules` menu
   * Add a rule using the `Whitelist` template and enter the emails that are allowed access to authorization.
   * Or create a rule with the following code (if the `Whitelist` template is not available in Auth0):
```javascript
function userWhitelist(user, context, callback) {
  // Access should only be granted to verified users.
  if (!user.email || !user.email_verified) {
    return callback(new UnauthorizedError('Access denied.'));
  }

  const whitelist = ['user1@example.com', 'user2@example.com']; // authorized users
  const userHasAccess = whitelist.some(
    function (email) {
      return email === user.email;
    });

  if (!userHasAccess) {
    return callback(new UnauthorizedError('Access denied.'));
  }

  callback(null, user, context);
}
```

## Useful links
Guide for setting up Auth0 in Blazor: https://auth0.com/blog/securing-blazor-webassembly-apps/
# Taviloglu.Wrike.ApiClient [![Build Status](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient.svg?branch=master)](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient/)
.NET Client for Wrike API 

## Donate
If you find this library useful and if it saved you time please think about supporting my work, I will appreciate that.
<a href="https://www.buymeacoffee.com/staviloglu" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

## Client Usage [![NuGet](https://img.shields.io/nuget/v/Taviloglu.Wrike.ApiClient.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.ApiClient/) [![NuGet Downloads](https://img.shields.io/nuget/dt/Taviloglu.Wrike.ApiClient.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.ApiClient/)
Create your Wrike Client and just call the function you need.
### Create client with permanent token
```csharp
var client = new WrikeClient("permanent_token");
```
### Create client with ClientId, ClientSecret, AuthorizationCode (Use oAuth2.0)
```csharp
//create the authorization url
var authorizationUrl = WrikeClient.GetAuthorizationUrl(
                ClientId,
                redirectUri: "http://localhost",
                state: "myTestState",
                scope: new List<string> { WrikeScopes.Default, WrikeScopes.wsReadWrite });
//After the user authorizes your client using the authroization url, 
//wrike will redirect user to the provided redirect_uri with the authorization code
//See https://developers.wrike.com/documentation/oauth2 for more details

//create client
var client = new WrikeClient(new WrikeAccessTokenRequest(
                ClientId,
                ClientSecret,
                AuthorizationCode), "redirect_uri");

//refresh token if needed
client.RefreshToken();
```
### Create client with AccessToken and Host
```csharp
var accesTokenResponse = WrikeClient.GetAccesToken(new WrikeAccessTokenRequest(
                ClientId,
                ClientSecret,
                AuthorizationCode), "http://localhost");

var client = new WrikeClient(accesTokenResponse.AccessToken, accesTokenResponse.Host);

//you need new client when you need to refresh token
var refreshTokenResponse = WrikeClient.RefreshToken(ClientId, ClientSecret, 
                accesTokenResponse.RefreshToken, accesTokenResponse.Host);

client = new WrikeClient(refreshTokenResponse.AccessToken, accesTokenResponse.Host);
```

### CRUD operations
```csharp
//create client
var client = new WrikeClient("permanent_token");

//get the list of custom fields
//https://developers.wrike.com/documentation/api/methods/query-custom-fields
var customFields = await client.CustomFields.GetAsync();

//create new custom field
//https://developers.wrike.com/documentation/api/methods/create-custom-field
var newCustomField = new WrikeCustomField("Title", WrikeCustomFieldType.Text);
newCustomField = await client.CustomFields.CreateAsync(newCustomField);

//delete a task
await client.Tasks.DeleteAsync("taskId");
```
For more details on usage checkout the [Taviloglu.Wrike.ApiClient.Samples](Taviloglu.Wrike.ApiClient.Samples) project

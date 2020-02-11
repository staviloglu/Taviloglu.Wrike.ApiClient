# Taviloglu.Wrike.ApiClient [![Build Status](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient.svg?branch=master)](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient/) [![BCH compliance](https://bettercodehub.com/edge/badge/staviloglu/Taviloglu.Wrike.ApiClient?branch=master)](https://bettercodehub.com/)
.NET Client for Wrike API 

## Donate
If you find this library useful and if it saved you time, you can <a href="https://iyzi.link/AAtdxA" target="_blank">support</a> my work.

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

## WebHooks Usage [![NuGet](https://img.shields.io/nuget/v/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/) [![NuGet Downloads](https://img.shields.io/nuget/dt/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/)
Create your WrikeWebHookController by subclassing and implementing [WrikeWebHookControllerBase](Taviloglu.Wrike.WebHook/Controllers/WrikeWebHookControllerBase.cs) abstract class provided in [Taviloglu.Wrike.WebHook](Taviloglu.Wrike.WebHook) library. Don't forget to set a route to your new controller. 

```csharp
    [Route("api/[controller]")]
    public class WrikeWebHookController : WrikeWebHookControllerBase
    {
        protected override void OnAttachmentAdded(WrikeWebHookEvent wrikeWebHookEvent)
        {
            throw new NotImplementedException();
        }
        
        /*
            implement other events...
        */
     }
```
When your WrikeWebHookController is ready for responding to post requests, create a webhook using the Wrike Client
```csharp
//create client
var client = new WrikeClient("permanent_token");
//create new webhook
//https://developers.wrike.com/documentation/webhooks
var newWebHook = new WrikeWebHook("https://<your-host>/api/wrikewebhook");
newWebHook = await client.WebHooks.CreateAsync(newWebHook);
```
Then Wrike will send post requests to the url you provided. For more details check out [wrike's documentation](https://developers.wrike.com/documentation/webhooks)

<table class="tableizer-firstrow">
<thead><tr><th title="Field #1">Endpoint</th>
<th title="Field #2">IsImplemented</th>
<th title="Field #3">Group</th>
</tr></thead>
<tbody><tr>
<td>[GET] /contacts</td>
<td>1</td>
<td rowspan="3">Contacts</td>
</tr>
<tr>
<td>[GET] /contacts/{contactId},{contactId},... - up to 100 IDs</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /contacts/{contactId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /users/{userId}</td>
<td>1</td>
<td rowspan="2">Users</td>
</tr>
<tr>
<td>[PUT] /users/{userId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /groups/{groupId}</td>
<td>1</td>
<td rowspan="5">Groups</td>
</tr>
<tr>
<td>[GET] /groups</td>
<td>1</td>
</tr>
<tr>
<td>[POST] /groups</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /groups/{groupId}</td>
<td>1</td>
</tr>
<tr>
<td>[DELETE] /groups/{groupId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /invitations</td>
<td>1</td>
<td rowspan="4">Invitations</td>
</tr>
<tr>
<td>[POST] /invitations</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /invitations/{invitationId}</td>
<td>1</td>
</tr>
<tr>
<td>[DELETE] /invitations/{invitationId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /account</td>
<td>1</td>
<td rowspan="2">Accounts</td>
</tr>
<tr>
<td>[PUT] /account</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /workflows</td>
<td>1</td>
<td rowspan="3">Workflows</td>
</tr>
<tr>
<td>[POST] /workflows</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /workflows/{workflowId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /customfields</td>
<td>1</td>
<td rowspan="4">Custom Fields</td>
</tr>
<tr>
<td>[GET] /customfields/{customfieldId},{customfieldId},... - up to 100 Ids</td>
<td>1</td>
</tr>
<tr>
<td>[POST] /customfields</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /customfields/{customfieldId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /folders</td>
<td>1</td>
<td rowspan="7">Folders &amp; Projects</td>
</tr>
<tr>
<td>[GET] /folders/{folderId}/folders</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /folders/{folderId},{folderId},... - up to 100 IDs</td>
<td>1</td>
</tr>
<tr>
<td>[POST] /folders/{folderId}/folders</td>
<td>1</td>
</tr>
<tr>
<td>[POST] /copy_folder/{folderId}</td>
<td>1</td>
</tr>
<tr>
<td>[PUT] /folders/{folderId}</td>
<td>1</td>
</tr>
<tr>
<td>[DELETE] /folders/{folderId}</td>
<td>1</td>
</tr>
<tr>
<td>[GET] /tasks</td>
<td>1</td>
<td rowspan="6">Tasks</td>
</tr>
<tr>
<td>[GET] /folders/{folderId}/tasks</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /tasks/{taskId},{taskId},... - up to 100 IDs</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /folders/{folderId}/tasks</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /tasks/{taskId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /tasks/{taskId}</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /comments</td>
<td>1</td>
<td rowspan="8">Comments</td>
</tr>
<tr>
<td>[GET] /folders/{folderId}/comments</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /tasks/{taskId}/comments</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /comments/{commentId},{commentId},... - up to 100 Ids</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /folders/{folderId}/comments</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /tasks/{taskId}/comments</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /comments/{commentId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /comments/{commentId}</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /tasks/{taskId}/dependencies</td>
<td>1</td>
<td rowspan="5">Dependencies</td>
</tr>
<tr>
<td>[GET] /dependencies/{dependencyId},{dependencyId},... - up to 100 IDs</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /tasks/{taskId}/dependencies</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /dependencies/{dependencyId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /dependencies/{dependencyId}</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /timelogs</td>
<td>1</td>
<td rowspan="9">Timelogs</td>
</tr>
<tr>
<td>[GET] /contacts/{contactId}/timelogs</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /folders/{folderId}/timelogs</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /tasks/{taskId}/timelogs</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /timelog_categories/{timelog_categoryId}/timelogs</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /timelogs/{timelogId}</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /tasks/{taskId}/timelogs</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /timelogs/{timelogId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /timelogs/{timelogId}</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /timelog_categories</td>
<td>1</td>
<td>Timelog Categories</td>
</tr>
<tr>
<td>[GET] /attachments</td>
<td>1</td>
<td rowspan="11">Attachments</td>
</tr>
<tr>
<td>[GET] /folders/{folderId}/attachments </td>
<td>1</td>

</tr>
<tr>
<td>[GET] /tasks/{taskId}/attachments</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /attachments/{attachmentId},{attachmentId},... - up to 100 Ids</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /attachments/{attachmentId}/download</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /attachments/{attachmentId}/preview </td>
<td>1</td>

</tr>
<tr>
<td>[GET] /attachments/{attachmentId}/url</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /folders/{folderId}/attachments</td>
<td>1</td>

</tr>
<tr>
<td>[POST] /tasks/{taskId}/attachments</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /attachments/{attachmentId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /attachments/{attachmentId}</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /version</td>
<td>1</td>
<td>Version</td>
</tr>
<tr>
<td>[GET] /ids</td>
<td>1</td>
<td>Ids</td>
</tr>
<tr>
<td>[GET] /colors</td>
<td>1</td>
<td>Colors</td>
</tr>
<tr>
<td>[POST] /folders/{folderId}/webhooks</td>
<td>1</td>
<td rowspan="5">Webhooks</td>
</tr>
<tr>
<td>[GET] /webhooks</td>
<td>1</td>

</tr>
<tr>
<td>[GET] /webhooks/{webhookId},{webhookId}</td>
<td>1</td>

</tr>
<tr>
<td>[PUT] /webhooks/{webhookId}</td>
<td>1</td>

</tr>
<tr>
<td>[DELETE] /webhooks/{webhookId}</td>
<td>1</td>

</tr>
<tr>
<td>[POST] https://www.wrike.com/oauth2/token (getToken)</td>
<td>1</td>
<td rowspan="2">oAuth2.0</td>
</tr>
<tr>
<td>[POST] https://www.wrike.com/oauth2/token (refreshToken)</td>
<td>1</td>

</tr>
</tbody></table>

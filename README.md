# Taviloglu.Wrike.ApiClient [![Build Status](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient.svg?branch=master)](https://travis-ci.org/staviloglu/Taviloglu.Wrike.ApiClient/)
.NET Client for Wrike API 

:boom: Latest working client (v0.89.0-alpha) works with Wrike API v3 and is not uploaded to NuGet. You can download the binaries and the source code from [Releases](https://github.com/staviloglu/Taviloglu.Wrike.ApiClient/releases/tag/v0.89.0-alpha) on github.

:boom: master branch is now under development for supporting Wrike API v4

## Donate
If you find this library useful and if it saved you time please think about supporting my work, I will appreciate that.
<a href="https://www.buymeacoffee.com/staviloglu" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

## Client Usage [![NuGet](https://img.shields.io/nuget/v/Taviloglu.Wrike.ApiClient.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.ApiClient/)[![NuGet Downloads](https://img.shields.io/nuget/dt/Taviloglu.Wrike.ApiClient.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.ApiClient/)
Create your Wrike Client with your permanent token and just call the function you need.
```csharp
//create client
var bearerToken = "your_permanent_token";
var wrikeClient = new WrikeClient(bearerToken);

//get the list of custom fields
//https://developers.wrike.com/documentation/api/methods/query-custom-fields
var customFields = await wrikeClient.CustomFields.GetAsync();

//create new custom field
//https://developers.wrike.com/documentation/api/methods/create-custom-field
var newCustomField = new WrikeCustomField
{
    AccountId = "IEABX2HE",
    Title = "Sinan's custom field",
    Type = WrikeCustomFieldType.Duration
};
newCustomField = await wrikeClient.CustomFields.CreateAsync(newCustomField);
```
For more details on usage checkout the [Taviloglu.Wrike.ApiClient.Samples](Taviloglu.Wrike.ApiClient.Samples) project

## Webhooks Usage [![NuGet](https://img.shields.io/nuget/v/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/)[![NuGet Downloads](https://img.shields.io/nuget/dt/Taviloglu.Wrike.WebHook.svg)](https://www.nuget.org/packages/Taviloglu.Wrike.WebHook/)
Create your WrikeWebHookController by subclassing and implementing [WrikeWebhookControllerBase](Taviloglu.Wrike.WebHook/Controllers/WrikeWebHookControllerBase.cs) abstract class provided in [Taviloglu.Wrike.WebHook](Taviloglu.Wrike.WebHook) library. Don't forget to set a route to your new controller. 

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
var bearerToken = "your_permanent_token";
var wrikeClient = new WrikeClient(bearerToken);
//create new webhook
//https://developers.wrike.com/documentation/webhooks
var newWebhook = new WrikeWebHook("accountId", "http://<your-host>/api/wrikewebhook");
newWebhook = await wrikeClient.WebHooks.CreateAsync(newWebhook);
```
Then Wrike will send post requests to the url you provided. For more details check out [wrike's documentation](https://developers.wrike.com/documentation/webhooks)

## 88% of the methods in [Wrike API 3.0 Documentation](https://developers.wrike.com/documentation-v3/api/overview) is implemented in client v0.89.0-alpha

<table>
<thead><tr class="tableizer-firstrow"><th>Mehod</th><th>IsImplemented</th><th>Group</th></tr></thead>
<tbody>
<tr><td>[GET] /contacts</td><td>1</td><td rowspan="4">Contacts</td></tr>
<tr><td>[GET] /accounts/{accountId}/contacts</td><td>1</td></tr>
<tr><td>[GET] /contacts/{contactId},{contactId},... - up to 100 IDs</td><td>1</td></tr>
<tr><td>[PUT] /contacts/{contactId}</td><td>1</td></tr>
 
 <tr><td>[GET] /users/{userId}</td><td>1</td><td rowspan="2">Users</td></tr>
 <tr><td>[PUT] /users/{userId}</td><td>1</td></tr>
 
 <tr><td>[GET] /groups/{groupId}</td><td>1</td><td rowspan="5">Groups</td></tr>
 <tr><td>[GET] /accounts/{accountId}/groups</td><td>1</td></tr>
 <tr><td>[POST] /accounts/{accountId}/groups</td><td>1</td></tr>
 <tr><td>[PUT] /groups/{groupId}</td><td>1</td></tr>
 <tr><td>[DELETE] /groups/{groupId}</td><td>1</td></tr>
 
 <tr><td>[GET] /accounts/{accountId}/invitations</td><td>1</td><td rowspan="4">Invitations</td></tr>
 <tr><td>[POST] /accounts/{accountId}/invitations</td><td>1</td></tr>
 <tr><td>[PUT] /invitations/{invitationId}</td><td>1</td></tr>
 <tr><td>[DELETE] /invitations/{invitationId}</td><td>1</td></tr>
 
 <tr><td>[GET] /accounts</td><td>1</td><td rowspan="3">Accounts</td></tr>
 <tr><td>[GET] /accounts/{accountId}</td><td>1</td></tr>
 <tr><td>[PUT] /accounts/{accountId}</td><td>1</td></tr>
 
 <tr><td>[GET] /accounts/{accountId}/workflows</td><td>1</td><td rowspan="3">Workflows</td></tr>
 <tr><td>[POST] /accounts/{accountId}/workflows</td><td>1</td></tr>
 <tr><td>[PUT] /workflows/{workflowId}</td><td>1</td></tr>
 
 <tr><td>[GET] /customfields</td><td>1</td><td rowspan="5">Custom Fields</td></tr>
 <tr><td>[GET] /accounts/{accountId}/customfields</td><td>1</td></tr>
 <tr><td>[GET] /customfields/{customfieldId},{customfieldId},... - up to 100 Ids</td><td>1</td></tr>
 <tr><td>[POST] /accounts/{accountId}/customfields</td><td>1</td></tr>
 <tr><td>[PUT] /customfields/{customfieldId}</td><td>1</td></tr>
 
 <tr><td>[GET] /folders</td><td>1</td><td rowspan="8">Folders & Projects</td></tr>
 <tr><td>[GET] /accounts/{accountId}/folders</td><td>1</td></tr>
 <tr><td>[GET] /folders/{folderId}/folders</td><td>1</td></tr>
 <tr><td>[GET] /folders/{folderId},{folderId},... - up to 100 IDs</td><td>1</td></tr>
 <tr><td>[POST] /folders/{folderId}/folders</td><td>1</td></tr>
 <tr><td>[POST] /copy_folder/{folderId}</td><td>0</td></tr>
 <tr><td>[PUT] /folders/{folderId}</td><td>1</td></tr>
 <tr><td>[DELETE] /folders/{folderId}</td><td>1</td></tr>
 
 <tr><td>[GET] /tasks</td><td>1</td><td rowspan="7">Tasks</td></tr>
 <tr><td>[GET] /accounts/{accountId}/tasks</td><td>1</td></tr>
 <tr><td>[GET] /folders/{folderId}/tasks</td><td>1</td></tr>
 <tr><td>[GET] /tasks/{taskId},{taskId},... - up to 100 IDs</td><td>1</td></tr>
 <tr><td>[POST] /folders/{folderId}/tasks</td><td>1</td></tr>
 <tr><td>[PUT] /tasks/{taskId}</td><td>1</td></tr>
 <tr><td>[DELETE] /tasks/{taskId}</td><td>1</td></tr>
 
 <tr><td>[GET] /comments</td><td>1</td><td rowspan="9">Comments</td></tr>
 <tr><td>[GET] /accounts/{accountId}/comments</td><td>1</td></tr>
 <tr><td>[GET] /folders/{folderId}/comments</td><td>1</td></tr>
 <tr><td>[GET] /tasks/{taskId}/comments</td><td>1</td></tr>
 <tr><td>[GET] /comments/{commentId},{commentId},... - up to 100 Ids</td><td>1</td></tr>
 <tr><td>[POST] /folders/{folderId}/comments</td><td>1</td></tr>
 <tr><td>[POST] /tasks/{taskId}/comments</td><td>1</td></tr>
 <tr><td>[PUT] /comments/{commentId}</td><td>1</td></tr>
 <tr><td>[DELETE] /comments/{commentId}</td><td>1</td></tr>
 
 <tr><td>[GET] /tasks/{taskId}/dependencies</td><td>0</td><td rowspan="5">Dependencies</td></tr>
 <tr><td>[GET] /dependencies/{dependencyId},{dependencyId},... - up to 100 IDs</td><td>0</td></tr>
 <tr><td>[POST] /tasks/{taskId}/dependencies</td><td>0</td></tr>
 <tr><td>[PUT] /dependencies/{dependencyId}</td><td>0</td></tr>
 <tr><td>[DELETE] /dependencies/{dependencyId}</td><td>0</td></tr>
 
 <tr><td>[GET] /timelogs</td><td>1</td><td rowspan="9">Timelogs</td></tr>
 <tr><td>[GET] /contacts/{contactId}/timelogs</td><td>1</td></tr>
 <tr><td>[GET] /accounts/{accountId}/timelogs</td><td>1</td></tr>
 <tr><td>[GET] /folders/{folderId}/timelogs</td><td>1</td></tr>
 <tr><td>[GET] /tasks/{taskId}/timelogs</td><td>1</td></tr>
 <tr><td>[GET] /timelogs/{timelogId}</td><td>1</td></tr>
 <tr><td>[POST] /tasks/{taskId}/timelogs</td><td>1</td></tr>
 <tr><td>[PUT] /timelogs/{timelogId}</td><td>1</td></tr>
 <tr><td>[DELETE] /timelogs/{timelogId}</td><td>1</td></tr>
 
 <tr><td>[GET] /accounts/{accountId}/timelog_categories</td><td>1</td><td>Timelog Categories</td></tr>
 
 
 <tr><td>[GET] /accounts/{accountId}/attachments</td><td>1</td><td rowspan="11">Attachments</td></tr>
 <tr><td>[GET] /folders/{folderId}/attachments </td><td>1</td></tr>
 <tr><td>[GET] /tasks/{taskId}/attachments</td><td>1</td></tr>
 <tr><td>[GET] /attachments/{attachmentId}</td><td>1</td></tr>
 <tr><td>[GET] /attachments/{attachmentId}/download</td><td>1</td></tr>
 <tr><td>[GET] /attachments/{attachmentId}/preview </td><td>1</td></tr>
 <tr><td>[GET] /attachments/{attachmentId}/url</td><td>0</td></tr>
 <tr><td>[POST] /folders/{folderId}/attachments</td><td>0</td></tr>
 <tr><td>[POST] /tasks/{taskId}/attachments</td><td>0</td></tr>
 <tr><td>[PUT] /attachments/{attachmentId}</td><td>0</td></tr>
 <tr><td>[DELETE] /attachments/{attachmentId}</td><td>0</td></tr>
 
 <tr><td>[GET] /version</td><td>1</td><td>Version</td></tr>
 
 <tr><td>[GET] /ids</td><td>1</td><td>Ids</td></tr>
 
 <tr><td>[GET] /colors</td><td>1</td><td>Colors</td></tr>
 
 <tr><td>[POST] /folders/{folderId}/webhooks</td><td>1</td><td rowspan="7">Webhooks</td></tr>
 <tr><td>[POST] /accounts/{accountId}/webhooks</td><td>1</td></tr>
 <tr><td>[GET] /webhooks</td><td>1</td></tr>
 <tr><td>[GET] /accounts/{accountId}/webhooks</td><td>1</td></tr>
 <tr><td>[GET] /webhooks/{webhookId},{webhookId}</td><td>1</td></tr>
 <tr><td>[PUT] /webhooks/{webhookId}</td><td>1</td></tr>
 <tr><td>[DELETE] /webhooks/{webhookId}</td><td>1</td></tr>
</tbody>
</table>

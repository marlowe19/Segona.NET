# Segona.NET
Client for Segona Api


Segona.NET provides an easy way to connect the segona api.


Basic usage:
```C#
var client = SegonaClient.Create(new SegonaOptions("<ApiUrl>", "<ApiKey>"));

// which is short for
// var options = new SegonaOptions("<ApiUrl>", "<ApiKey>");
// var client = new SegonaClient(new SegonaRestHandler(new Uri(options.ApiUrl)), options.ApiKey)';
var response = await client.GetAllAssetsAsync();
```

If you want dependency injection:
```C#
IServicesCollection.AddSegona(configure => 
{
    configure.Options = new SegonaOption("<ApiUrl>", "<ApiKey>"));
    // Optinally you can add your HttpClient instance
    configure.HttpClient = new HttpClient();
};
```

Available methods:
```C#
Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()

Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)

Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Guid id)

Task<SegonaResponse<AssetList>> SearchAssets(string query, int limit = 50)

Task<SegonaResponse<AssetList>> FilteredSearchAssets(string query, int limit = 50, string extraQuery = null, string color = null)

Task<SegonaResponse<UploadUrlObject>> GetUploadUrl()
```
------------------------------------------------
for more information about Segona visit www.segona.io

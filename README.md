# Segona.NET
Client for Segona Api


Segona.NET provides an easy way to connect the segona api.


Basic usage:
```C#
var client = SegonaClient.Create(new SegonaOptions { ApiKey = "...", ApiUrl = "..." });
var response = await client.GetAllAssetsAsync();

which is short for
var client = new SegonaClient(new SegonaRestHandler(new Uri(options.ApiUrl)), options.ApiKey)';
var response = await client.GetAllAssetsAsync();
```

If you want dependency injection:
```C#
IServicesCollection.AddSegona(configure => configure.Options = new SegonaOption{ ApiKey = "...", ApiUrl = "..." });

Optionally you can add your HttpClient instance

IServicesCollection.AddSegona(configure => 
{
    configure.Options = new SegonaOption{ ApiKey = "...", ApiUrl = "..." });
    configure.HttpClient = new HttpClient();
};
```

Available methods:
```C#
public async Task<SegonaResponse<Keycheck>> ApiKeyCheckAsync()

public async Task<SegonaResponse<AssetList>> GetAllAssetsAsync(int limit = 50, int? startFromId = null)

public async Task<SegonaResponse<AssetDetail>> GetSpecificAssetAsync(Guid id)

public async Task<SegonaResponse<AssetList>> SearchAssets(string query, int limit = 50)

public async Task<SegonaResponse<AssetList>> FilteredSearchAssets(string query, int limit = 50, string extraQuery = null, string color = null)

public async Task<SegonaResponse<UploadUrlObject>> GetUploadUrl()
```
------------------------------------------------
for more information about Segona visit www.segona.io

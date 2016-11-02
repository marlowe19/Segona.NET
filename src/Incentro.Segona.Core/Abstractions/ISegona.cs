using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Incentro.Segona.Core.Models;

namespace Incentro.Segona.Core.Abstractions
{
    public interface ISegona
    {
        Task<SegonaResponse<AssetList>> GetAllAssetsAsync(string apiKey, int limit = 50, int? startFromId = null);
    }
}

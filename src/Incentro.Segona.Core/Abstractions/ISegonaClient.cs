using System.Threading.Tasks;

namespace Incentro.Segona.Core.Abstractions
{
    public interface ISegonaClient
    {
        Task<IResponse> SearchAsync(RequestSettings settings);
        Task<T> GetAssetById<T>(RequestSettings settings) where T : IAsset;
        Task<IResponse> GetAllAsync(RequestSettings settings);
        Task<IResponse> FilterAsync(RequestSettings settings);
    }
}
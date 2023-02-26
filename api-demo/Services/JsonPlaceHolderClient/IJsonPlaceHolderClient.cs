using ApiDemo.Models;

namespace ApiDemo.Services.JsonPlaceHolderClient
{
    public interface IJsonPlaceHolderClient
    {
        Task<JPHResponse> GetJPHResponse();
    }
}
using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.Villa;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services;

public class VillaService : BaseService, IVillaService
{
    private readonly IHttpClientFactory _clientFactory;
    private string villaUrl;
    
    public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/villaAPI"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/villaAPI/" + id
        });
    }

    public Task<T> CreateAsync<T>(VillaCreateDto dto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = dto,
            Url = villaUrl + "/api/villaAPI"
        });
    }

    public Task<T> UpdateAsyc<T>(VillaUpdateDto dto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = dto,
            Url = villaUrl + "/api/villaAPI/" + dto.Id
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = villaUrl + "/api/villaAPI/" + id
        });
    }
}
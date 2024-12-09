using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.VillaNumber;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services;

public class VillaNumberService : BaseService, IVillaNumberService
{
    private readonly IHttpClientFactory _clientFactory;
    private string villaUrl;

    public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

    }

    public Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = dto,
            Url = villaUrl + "/api/v1/villaNumberAPI",
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.DELETE,
            Url = villaUrl + "/api/v1/villaNumberAPI/" + id,
        });
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/v1/villaNumberAPI",
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.GET,
            Url = villaUrl + "/api/v1/villaNumberAPI/" + id,
        });
    }

    public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.PUT,
            Data = dto,
            Url = villaUrl + "/api/v1/villaNumberAPI/" + dto.VillaNo,
        }) ;
    }
}
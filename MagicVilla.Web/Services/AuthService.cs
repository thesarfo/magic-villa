using MagicVilla_Utility;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.User;
using MagicVilla.Web.Services.IServices;

namespace MagicVilla.Web.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IHttpClientFactory _clientFactory;
    private string _villaUrl;

    public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

    }

    public Task<T> LoginAsync<T>(LoginRequestDto obj)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = obj,
            Url = _villaUrl + $"/api/{SD.CurrentApiVersion}/UsersAuth/login"
        });
    }

    public Task<T> RegisterAsync<T>(RegistrationRequestDto obj)
    {
        return SendAsync<T>(new ApiRequest()
        {
            ApiType = SD.ApiType.POST,
            Data = obj,
            Url = _villaUrl + $"/api/{SD.CurrentApiVersion}/UsersAuth/register"
        });
    }
}
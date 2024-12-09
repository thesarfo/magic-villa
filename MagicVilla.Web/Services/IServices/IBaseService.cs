using MagicVilla.Web.Models;

namespace MagicVilla.Web.Services.IServices;

public interface IBaseService
{
    public ApiResponse responseModel { get; set; }
    
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}
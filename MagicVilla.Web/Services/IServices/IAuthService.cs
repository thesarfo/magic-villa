using MagicVilla.Web.Models.Dto.User;

namespace MagicVilla.Web.Services.IServices;

public interface IAuthService
{
    Task<T> LoginAsync<T>(LoginRequestDto objToCreate);
    Task<T> RegisterAsync<T>(RegistrationRequestDto objToCreate);
}
using MagicVilla.Web.Models.Dto.VillaNumber;

namespace MagicVilla.Web.Services.IServices;

public interface IVillaNumberService
{
    Task<T> GetAllAsync<T>(string token);
    
    Task<T> GetAsync<T>(int id, string token);
    
    Task<T> CreateAsync<T>(VillaNumberCreateDto dto, string token);
    
    Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto, string token);
    
    Task<T> DeleteAsync<T>(int id, string token);
}
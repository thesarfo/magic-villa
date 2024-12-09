using MagicVilla.Web.Models.Dto.Villa;

namespace MagicVilla.Web.Services.IServices;

public interface IVillaService
{
    Task<T> GetAllAsync<T>();
    
    Task<T> GetAsync<T>(int id);
    
    Task<T> CreateAsync<T>(VillaCreateDto dto);
    
    Task<T> UpdateAsyc<T>(VillaUpdateDto dto);
    
    Task<T> DeleteAsync<T>(int id);
}
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IBrandAppService
    {
        Task<ICollection<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdDtoAsync(string id);
        Task<BrandDto> UpdateAsync(BrandDto brand);
        Task<bool> Delete(string id);
        Task<BrandDto> CreateAsync(CreateBrandDto brand);
    }
}
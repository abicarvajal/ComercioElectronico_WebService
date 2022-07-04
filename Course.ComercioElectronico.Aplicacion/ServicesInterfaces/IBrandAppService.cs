using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IBrandAppService
    {
        //Task<ICollection<Brand>> GetAsync();
        Task<ICollection<BrandDto>> GetAllAsync();
        //Task<Brand> GetByIdAsync(string id);
        Task<BrandDto> GetByIdDtoAsync(string id);
        //Task<Brand> UpdateAsync(Brand brand);
        Task<BrandDto> UpdateAsync(BrandDto brand);
        Task<bool> Delete(BrandDto brand);
        //Task<Brand> CreateAsync(Brand brand);
        Task<BrandDto> CreateAsync(CreateBrandDto brand);
    }
}
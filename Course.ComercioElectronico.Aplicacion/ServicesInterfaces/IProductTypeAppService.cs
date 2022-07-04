using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IProductTypeAppService
    {
        Task<ICollection<ProductType>> GetAsync();
        Task<ProductType> GetByIdAsync(string code);
        Task<ProductType> UpdateAsync(ProductType productType);
        Task<bool> Delete(ProductType productType);
        Task<ProductType> CreateAsync(ProductType productType);
        //using DTO
        //Task<ICollection<ProductTypeDto>> GetAsync();
        //Task<ProductTypeDto> GetByIdAsync(string code);
    }
}
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IProductTypeAppService
    {
        Task<ICollection<ProductTypeDto>> GetAsync();
        Task<ProductType> GetByIdAsync(string code);
        Task<ProductType> UpdateAsync(ProductType productType);
        Task<bool> Delete(string id);
        Task<ProductType> CreateAsync(ProductType productType);
        //Task<ICollection<ProductTypeDto>> GetAllAsync();
        //Task<ProductTypeDto> GetByIdDtoAsync(string id);
        //Task<ProductTypeDto> UpdateAsync(ProductTypeDto brand);
        //Task<bool> Delete(string id);
        //Task<ProductTypeDto> CreateAsync(CreateProductTypeDto brand);
    }
}
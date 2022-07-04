using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IProductAppService
    {
        Task<ICollection<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> UpdateAsync(CreateProductDto product, Guid id);
        Task<bool> Delete(CreateProductDto product, Guid id);
        Task<ProductDto> CreateAsync(CreateProductDto product);
        Task<ICollection<ProductDto>> GetListAsync(int limit = 10, int offset = 0);
    }
}
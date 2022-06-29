using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IProductAppService
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> UpdateAsync(Product product);
        Task<bool> Delete(Product product);
        Task<Product> CreateAsync(Product product);
    }
}
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Infraestructura
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetByIdAsync(Guid id);
    }
}
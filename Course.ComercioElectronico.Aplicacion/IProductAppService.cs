using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IProductAppService
    {
        Task<ICollection<Product>> GetAsync();
        Task<Product> GetByIdAsync(Guid id);
    }
}
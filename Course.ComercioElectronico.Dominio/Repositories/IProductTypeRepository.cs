using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ICollection<ProductType>> GetAsync();
        Task<ProductType> GetByIdAsync(string code);
    }
}
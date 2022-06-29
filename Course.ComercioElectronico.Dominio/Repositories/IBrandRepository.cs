using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public interface IBrandRepository
    {
        Task<ICollection<Brand>> GetAsync();
        Task<Brand> GetByIdAsync(Guid id);
    }
}
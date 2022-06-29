using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IBrandAppService
    {
        Task<ICollection<Brand>> GetAsync();
        Task<Brand> GetByIdAsync(string id);
    }
}
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IBrandAppService
    {
        Task<ICollection<Brand>> GetAsync();
        Task<Brand> GetByIdAsync(string id);
        Task<Brand> UpdateAsync(Brand brand);
        Task<bool> Delete(Brand brand);
        Task<Brand> CreateAsync(Brand brand);
    }
}
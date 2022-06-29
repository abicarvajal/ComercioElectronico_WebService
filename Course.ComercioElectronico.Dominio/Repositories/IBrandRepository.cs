using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public interface IBrandRepository
    {
        Task<ICollection<Brand>> GetAsync();
        Task<Brand> GetByIdAsync(Guid id);
        
    }
}
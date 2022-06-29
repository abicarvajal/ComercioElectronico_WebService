using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class BrandAppService : IBrandAppService
    {
        protected IGenericRepository<Brand> repository { get; set; }


        public BrandAppService(IGenericRepository<Brand> repositorio)
        {
            this.repository = repositorio;

        }

        public Task<ICollection<Brand>> GetAsync()
        {
            return repository.GetAsync();
        }

        public Task<Brand> GetByIdAsync(string id)
        {
            return repository.GetByIdAsync(id);
        }
    }
}

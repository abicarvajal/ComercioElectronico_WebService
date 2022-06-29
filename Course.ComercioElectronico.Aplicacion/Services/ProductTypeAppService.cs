using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class ProductTypeAppService : IProductTypeAppService
    {
        protected IGenericRepository<ProductType> repository { get; set; }

        public ProductTypeAppService(IGenericRepository<ProductType> repository)
        {
            this.repository = repository;
        }

        public Task<ICollection<ProductType>> GetAsync()
        {
            return repository.GetAsync();
        }

        public Task<ProductType> GetByIdAsync(string code)
        {
            return repository.GetByIdAsync(code);
        }
    }
}

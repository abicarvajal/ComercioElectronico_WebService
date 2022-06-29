using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Services
{
    public class ProductAppService : IProductAppService
    {
        protected IGenericRepository<Product> repository { get; set; }


        public ProductAppService(IGenericRepository<Product> repositorio)
        {
            this.repository = repositorio;

        }

        public Task<ICollection<Product>> GetAsync()
        {
            return repository.GetAsync();
        }

        public Task<Product> GetByIdAsync(Guid id)
        {
            return repository.GetByIdAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            await repository.UpdateAsync(product);
            return await GetByIdAsync(product.Id);
        }

        public async Task<bool> Delete(Product product)
        {
            await repository.Delete(product);
            return true;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await repository.CreateAsync(product);
            return await GetByIdAsync(product.Id);
        }
    }
}

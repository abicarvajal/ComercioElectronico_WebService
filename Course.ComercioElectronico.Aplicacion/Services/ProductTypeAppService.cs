using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
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

        public async Task<ProductType> UpdateAsync(ProductType productType)
        {
            await repository.UpdateAsync(productType);
            return await GetByIdAsync(productType.Code);
        }

        public async Task<bool> Delete(ProductType productType)
        {
            await repository.Delete(productType);
            return true;
        }

        public async Task<ProductType> CreateAsync(ProductType productType)
        {
            await repository.CreateAsync(productType);
            return await GetByIdAsync(productType.Code);
        }
    }
}

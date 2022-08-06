using AutoMapper;
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<ProductTypeDto>> GetAsync()
        {
            var query = repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false).Select(x => new ProductTypeDto
            {
                Code = x.Code,
                Description = x.Description,
                CreatedDate = x.CreationDate
            });

            return await result.ToListAsync();
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

        public async Task<bool> Delete(string id)
        {
            //Borrado logico
            var newProductType = await repository.GetByIdAsync(id);
            newProductType.IsDeleted = true;

            await repository.UpdateAsync(newProductType);
            return true;
        }

        public async Task<ProductType> CreateAsync(ProductType productType)
        {
            await repository.CreateAsync(productType);
            return await GetByIdAsync(productType.Code);
        }
    }
}

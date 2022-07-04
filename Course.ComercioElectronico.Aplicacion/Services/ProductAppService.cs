using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<ProductDto>> GetAllAsync()
        {
            var query = repository.GetQueryable();
            var result = query.Where(x=> x.IsDeleted == false).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductyTypeId = x.ProductType.Description,
                BrandId = x.Brand.Description
            });

            return await result.ToListAsync();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = repository.GetQueryable();
            query = query.Where(x => x.Id == id);
            var result = query.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductyTypeId = x.ProductType.Description,
                BrandId = x.Brand.Description
            });

            return await result.SingleOrDefaultAsync();
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto productDto)
        {
            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name= productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CreationDate = DateTime.Now,
                BrandId = productDto.BrandId,
                ProductTypeId = productDto.ProductyTypeId
            };
            await repository.CreateAsync(newProduct);
            return await GetByIdAsync(newProduct.Id);
        }

        public async Task<ProductDto> UpdateAsync(CreateProductDto productDto, Guid id)
        {
            var newProduct = await repository.GetByIdAsync(id);
            newProduct.Name = productDto.Name;
            newProduct.Description = productDto.Description;
            newProduct.Price = productDto.Price;
            newProduct.ProductTypeId = productDto.ProductyTypeId;
            newProduct.BrandId = productDto.BrandId;
            newProduct.ModifiedDate = DateTime.Now;
            await repository.UpdateAsync(newProduct);
            return await GetByIdAsync(id);
        }

        public async Task<bool> Delete(CreateProductDto productDto, Guid id)
        {
            var newProduct = await repository.GetByIdAsync(id);
            newProduct.IsDeleted = true;
            
            await repository.UpdateAsync(newProduct);
            return true;
        }

        public async Task<ICollection<ProductDto>> GetListAsync(int limit = 10, int offset = 0)
        {
            var result = await repository.GetListAsync(limit,offset);
            return result.Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                BrandId = x.BrandId,
                ProductyTypeId = x.ProductTypeId
            }).ToList();
        }
    }
}

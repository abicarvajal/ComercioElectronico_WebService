using AutoMapper;
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
        private readonly IMapper mapper;

        public ProductAppService(IGenericRepository<Product> repositorio,IMapper mapper)
        {
            this.repository = repositorio;
            this.mapper = mapper;
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
            //Esto esta bien con proyeccion de LINQ
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
            //Con proyecciones
            //var newProduct = new Product
            //{
            //    Id = Guid.NewGuid(),
            //    Name= productDto.Name,
            //    Description = productDto.Description,
            //    Price = productDto.Price,
            //    CreationDate = DateTime.Now,
            //    BrandId = productDto.BrandId,
            //    ProductTypeId = productDto.ProductyTypeId
            //};

            #region Con el automapper
            var newProduct = mapper.Map<Product>(productDto);
            newProduct.Id = Guid.NewGuid();
            newProduct.CreationDate = DateTime.Now;
            #endregion

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

        public async Task<bool> Delete(Guid id)
        {
            //Borrado logico
            var newProduct = await repository.GetByIdAsync(id);
            newProduct.IsDeleted = true;
            
            await repository.UpdateAsync(newProduct);
            return true;
        }

        public async Task<ResultPagination<ProductDto>> GetListAsync(string? search = "", int limit = 10, int offset = 0, string sort = "Name", string order = "asc")
        {
            var query = repository.GetQueryable();

            //Filtrando los eliminados
            query = query.Where(x => x.IsDeleted == false);

            //Search
            if (!string.IsNullOrEmpty(search))
            {
                //Filter multi-fields
                query = query.Where(
                        x => x.Name.ToUpper().Contains(search));
                        //|| x.Code.ToUpper().StartsWith(search);
            }

            //1. Total
            var total = await query.CountAsync();
            //2. Pagination
            query = query
                .Skip(offset)
                .Take(limit);

            //3. Order
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToUpper())
                {
                    case "NAME":
                        query = query.OrderBy(x => x.Name);
                        break;
                    case "PRICE":
                        query = query.OrderBy(x => x.Price);
                        break;
                    default:
                        throw new ArgumentException($"The parameter sort {sort} not support");
                        break;
                }
            }

            //var result = await repository.GetListAsync(limit,offset);
            var queryDto = query.Select(x => new ProductDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                BrandId = x.BrandId,
                ProductyTypeId = x.ProductTypeId
            });

            var items = await queryDto.ToListAsync();
            var result = new ResultPagination<ProductDto>();
            result.Total = total;
            result.Items = items;
            return result;
        }
    }
}

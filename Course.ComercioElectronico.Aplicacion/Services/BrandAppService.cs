using AutoMapper;
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
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
        private readonly IMapper mapper;

        public BrandAppService(IGenericRepository<Brand> repositorio, IMapper mapper)
        {
            this.repository = repositorio;
            this.mapper = mapper;
        }

        public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
        {
            var newBrand = new Brand
            {
                Code = brandDto.Code,
                Description = brandDto.Description,
                CreationDate = brandDto.CreatedDate,
                ModifiedDate = DateTime.Now
            };
            await repository.UpdateAsync(newBrand);
            return await GetByIdDtoAsync(newBrand.Code);
        }

        public async Task<bool> Delete(BrandDto brandDto)
        {
            var newBrand = new Brand
            {
                Code = brandDto.Code,
                Description = brandDto.Description,
                CreationDate = brandDto.CreatedDate,
                ModifiedDate = DateTime.Now
            };
            await repository.Delete(newBrand);
            return true;
        }

        public async Task<BrandDto> CreateAsync(CreateBrandDto brandDto)
        {
            #region Proyeccion
            //var newBrand = new Brand
            //{
            //    Code = brandDto.Code,
            //    Description = brandDto.Description,
            //    CreationDate = DateTime.Now
            //};
            #endregion

            #region Automapper
            var newBrand = mapper.Map<Brand>(brandDto);
            newBrand.CreationDate = DateTime.Now;
            #endregion

            await repository.CreateAsync(newBrand);
            return await GetByIdDtoAsync(newBrand.Code);
        }

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query = await repository.GetAsync();

            var result = query.Select(x => new BrandDto
            {
                Code = x.Code,
                Description = x.Description,
                CreatedDate = x.CreationDate
            });

            return result.ToList();
        }

        public async Task<BrandDto> GetByIdDtoAsync(string id)
        {
            var entity = await repository.GetByIdAsync(id);
            return new BrandDto
            {
                Code = entity.Code,
                Description = entity.Description,
                CreatedDate = entity.CreationDate
            };
        }
    }
}

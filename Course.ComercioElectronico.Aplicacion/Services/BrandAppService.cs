using AutoMapper;
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Course.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
        private readonly IValidator<CreateBrandDto> validator;

        public BrandAppService(IGenericRepository<Brand> repositorio, IMapper mapper, IValidator<CreateBrandDto> validator)
        {
            this.repository = repositorio;
            this.mapper = mapper;
            this.validator = validator;
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

        public async Task<bool> Delete(string id)
        {
            //Borrado logico
            var newBrand = await repository.GetByIdAsync(id);
            newBrand.IsDeleted = true;

            await repository.UpdateAsync(newBrand);
            return true;
        }

        public async Task<BrandDto> CreateAsync(CreateBrandDto brandDto)
        {
            #region Proyeccion
            var newBrand = new Brand
            {
                Code = brandDto.Code,
                Description = brandDto.Description,
                CreationDate = DateTime.Now
            };
            #endregion

            //await validator.ValidateAndThrowAsync(brandDto);

            //#region Automapper
            //var newBrand = mapper.Map<Brand>(brandDto);
            //newBrand.CreationDate = DateTime.Now;
            //#endregion

            await repository.CreateAsync(newBrand);
            return await GetByIdDtoAsync(newBrand.Code);
        }

        public async Task<ICollection<BrandDto>> GetAllAsync()
        {
            var query = repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false).Select(x => new BrandDto
            {
                Code = x.Code,
                Description = x.Description,
                CreatedDate = x.CreationDate
            });

            return await result.ToListAsync();
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

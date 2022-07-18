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
    public class DeliveryMethodAppService : IDeliveryMethodAppService
    {
        protected IGenericRepository<DeliveryMethod> repository { get; set; }
        private readonly IMapper mapper;
        private readonly IValidator<CreateDeliveryMethodDto> validator;

        public DeliveryMethodAppService(IGenericRepository<DeliveryMethod> repository, IMapper mapper, IValidator<CreateDeliveryMethodDto> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            var query = repository.GetQueryable();
            var result = query.Where(x => x.IsDeleted == false).Select(x => new DeliveryMethodDto
            {
                Code = x.Code,
                Description = x.Description,
                Price = x.Price,
                DeliveryTime = x.DeliveryTime,
                CreatedDate = x.CreationDate
            });

            return await result.ToListAsync();
        }

        public async Task<DeliveryMethodDto> GetByIdDtoAsync(string id)
        {
            var entity = await repository.GetByIdAsync(id);
            return new DeliveryMethodDto
            {
                Code = entity.Code,
                Description = entity.Description,
                Price = entity.Price,
                DeliveryTime = entity.DeliveryTime,
                CreatedDate = entity.CreationDate
            };
        }

        public async Task<DeliveryMethodDto> UpdateAsync(DeliveryMethodDto deliveryMethodDto)
        {
            var newDeliveryMethod = new DeliveryMethod
            {
                Code = deliveryMethodDto.Code,
                Description = deliveryMethodDto.Description,
                CreationDate = deliveryMethodDto.CreatedDate,
                ModifiedDate = DateTime.Now,
                Price = deliveryMethodDto.Price,
                DeliveryTime= deliveryMethodDto.DeliveryTime,
            };
            await repository.UpdateAsync(newDeliveryMethod);
            return await GetByIdDtoAsync(newDeliveryMethod.Code);
        }

        public async Task<bool> Delete(string id)
        {
            //Borrado Logico
            var newDeliveryMethod = await repository.GetByIdAsync(id);
            newDeliveryMethod.IsDeleted = true;

            await repository.UpdateAsync(newDeliveryMethod);
            return true;
        }

        public async Task<DeliveryMethodDto> CreateAsync(CreateDeliveryMethodDto deliveryMethod)
        {
            var newDeliveryMethod = new DeliveryMethod
            {
                Code = deliveryMethod.Code,
                Description = deliveryMethod.Description,
                CreationDate = DateTime.Now
            };

            await repository.CreateAsync(newDeliveryMethod);
            return await GetByIdDtoAsync(newDeliveryMethod.Code);
        }
    }
}

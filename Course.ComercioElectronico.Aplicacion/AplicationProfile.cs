using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public class AplicationProfile : Profile
    {
        public AplicationProfile()
        {
            //CreateMap<Origen, Destino>
            CreateMap<ProductDto, Product>();
            CreateMap<ProductTypeDto, ProductType>();
            CreateMap<BrandDto, Brand>();

            CreateMap<CreateProductDto, ProductDto>();
            CreateMap<CreateBrandDto, BrandDto>();
        }
    }
}

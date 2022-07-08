using Course.ComercioElectronico.Aplicacion.Services;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.Dependencies
{
    public static class AplicationServiceColllectionExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IProductTypeAppService, ProductTypeAppService>();
            services.AddTransient<IBrandAppService, BrandAppService>();

            //Automapper: Add all profiles of this project
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

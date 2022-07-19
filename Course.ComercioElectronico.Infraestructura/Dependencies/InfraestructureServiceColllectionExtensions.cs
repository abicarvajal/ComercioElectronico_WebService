using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Dependencies
{
    public static class InfraestructureServiceColllectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            //service.AddScoped<IFoo, Foo>();
            services.AddDbContext<ComercioElectronicoDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ComercioElectronico"));
            });
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<ICalculationRepository, CalculationRepository>();
            return services;
        }
    }
}

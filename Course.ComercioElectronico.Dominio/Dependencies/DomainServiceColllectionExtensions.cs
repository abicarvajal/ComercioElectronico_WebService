using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Dependencies
{
    public static class DomainServiceColllectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration config)
        {
            //service.AddScoped<IFoo, Foo>();
            return services;
        }
    }
}

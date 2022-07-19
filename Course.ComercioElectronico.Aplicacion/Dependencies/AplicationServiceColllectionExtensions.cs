﻿using Course.ComercioElectronico.Aplicacion.Services;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Aplicacion.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Course.ComercioElectronico.Aplicacion.Dependencies
{
    public static class AplicationServiceColllectionExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IProductAppService, ProductAppService>();
            services.AddTransient<IProductTypeAppService, ProductTypeAppService>();
            services.AddTransient<IBrandAppService, BrandAppService>();
            services.AddTransient<IDeliveryMethodAppService, DeliveryMethodAppService>();

            //Add validations
            services.AddValidatorsFromAssemblyContaining<BrandValidation>();
            services.AddValidatorsFromAssemblyContaining<ProductTypeValidation>();
            services.AddValidatorsFromAssemblyContaining<ProductValidation>();
            //
            services.AddValidatorsFromAssemblyContaining<DeliveryMethodValidation>();
            services.AddValidatorsFromAssemblyContaining<OrderValidation>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<ICalculationAppService, CalculationAppService>();

            //Automapper: Add all profiles of this project
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

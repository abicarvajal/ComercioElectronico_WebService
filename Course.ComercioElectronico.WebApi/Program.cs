using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Aplicacion.Services;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura;
using Course.ComercioElectronico.Infraestructura.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Agregar conexion a base de datos
builder.Services.AddDbContext<ComercioElectronicoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComercioElectronico"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar o configurar las dependencias
//ICatalogoRepositorio => CatalogoRepositorio
//ICatalogoAplicacion => CatalogoAplicacion
//Aspnet es el tercer actor que crea las dependencias
//Configurar dependencias. Se lo realiza con IServiceCollection

//Forma Generica
builder.Services.AddTransient<ICatalogoRepositorio,CatalogoRepositorio>();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();

builder.Services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddTransient<IProductTypeAppService, ProductTypeAppService>();

builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<IBrandAppService, BrandAppService>();

//Forma Metodos
builder.Services.AddTransient(typeof(ICatalogoAplicacion), typeof(CatalogoAplicacion));
//Agrego repositorio generico
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

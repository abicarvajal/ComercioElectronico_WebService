using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Aplicacion.Dependencies;
using Course.ComercioElectronico.Aplicacion.Services;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Dependencies;
using Course.ComercioElectronico.Dominio.Repositories;
using Course.ComercioElectronico.Infraestructura;
using Course.ComercioElectronico.Infraestructura.Dependencies;
using Course.ComercioElectronico.Infraestructura.Repositories;
using Course.ComercioElectronico.WebApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddControllers(options =>
{
    //Aplicar filter globalmente a todos los controller
    options.Filters.Add<ApiExceptionFilterAttribute>();
})
;

//Add services to container
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddAplication(builder.Configuration);


//Agregar conexion a base de datos
//builder.Services.AddDbContext<ComercioElectronicoDBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ComercioElectronico"));
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EsEcuatoriano", policy => policy.RequireClaim("Ecuatoriano"));
    options.AddPolicy("GrupoAuth", policy => 
    { 
        policy.RequireClaim("Ecuatoriano");
        policy.RequireClaim(ClaimTypes.Role, "Admin");
    }
    );
    options.AddPolicy("Ubicacion", policy => policy.RequireClaim("Ubicacion"));
});

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));

//Inyectar o configurar las dependencias
//ICatalogoRepositorio => CatalogoRepositorio
//ICatalogoAplicacion => CatalogoAplicacion
//Aspnet es el tercer actor que crea las dependencias
//Configurar dependencias. Se lo realiza con IServiceCollection

//Forma Generica
builder.Services.AddTransient<ICatalogoRepositorio,CatalogoRepositorio>();

//builder.Services.AddTransient<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IProductAppService, ProductAppService>();

//builder.Services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
//builder.Services.AddTransient<IProductTypeAppService, ProductTypeAppService>();

//builder.Services.AddTransient<IBrandRepository, BrandRepository>();
//builder.Services.AddTransient<IBrandAppService, BrandAppService>();

//Forma Metodos
builder.Services.AddTransient(typeof(ICatalogoAplicacion), typeof(CatalogoAplicacion));
//Agrego repositorio generico
//builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

//Add Cors
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//CORS Global Policy. Middleware
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

//2.Add Middleware that uses authentication schema registered  
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    //3. Establecer la autorizacion para los controladores que se desee
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase, IProductTypeAppService
    {
        private readonly IProductTypeAppService productTypeAplication;

        public ProductTypeController(IProductTypeAppService productTypeAplication)
        {
            this.productTypeAplication = productTypeAplication;
        }

        [HttpPost]
        public Task<ProductType> CreateAsync(ProductType productType)
        {
            return productTypeAplication.CreateAsync(productType);
        }

        [HttpDelete]
        public Task<bool> Delete(string id)
        {
            return productTypeAplication.Delete(id);
        }

        //[Authorize(Roles ="Admin")]
        //[Authorize(Policy = "GrupoAuth")]
        //[Authorize(Policy = "EsEcuatoriano")]
        [HttpGet]
        public Task<ICollection<ProductTypeDto>> GetAsync()
        {
            return productTypeAplication.GetAsync();
        }

        //[Authorize(Policy = "EsEcuatoriano")]
        [HttpGet("{code}")]
        public Task<ProductType> GetByIdAsync(string code)
        {
            return productTypeAplication.GetByIdAsync(code);
        }

        [HttpPut]
        public Task<ProductType> UpdateAsync(ProductType productType)
        {
            return productTypeAplication.UpdateAsync(productType);
        }
    }
}

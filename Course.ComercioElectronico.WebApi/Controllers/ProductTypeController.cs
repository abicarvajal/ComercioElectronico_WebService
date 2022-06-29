using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
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
        public Task<bool> Delete(ProductType productType)
        {
            return productTypeAplication.Delete(productType);
        }

        [HttpGet]
        public Task<ICollection<ProductType>> GetAsync()
        {
            return productTypeAplication.GetAsync();
        }

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

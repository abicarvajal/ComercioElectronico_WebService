using Course.ComercioElectronico.Aplicacion;
using Course.ComercioElectronico.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase, ICatalogoAplicacion
    {
        private readonly ICatalogoAplicacion catalogoAplicacion;

        public CatalogoController(ICatalogoAplicacion catalogoAplicacion)
        {
            this.catalogoAplicacion = catalogoAplicacion;
        }

        [HttpGet]
        public Task<ICollection<Catalogo>> ObtenerAsync()
        {
            return catalogoAplicacion.ObtenerAsync();
        }
    }
}

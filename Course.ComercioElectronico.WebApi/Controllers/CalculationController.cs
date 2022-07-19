using Course.ComercioElectronico.Aplicacion.DTOs;
using Course.ComercioElectronico.Aplicacion.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.ComercioElectronico.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase, ICalculationAppService
    {
        private readonly ICalculationAppService _calculationAppService;

        public CalculationController(ICalculationAppService calculationAppService)
        {
            _calculationAppService = calculationAppService;
        }

        [HttpGet]
        public Task<DetailOrderDto> CalculateTotalOfOrder(string id)
        {
            return _calculationAppService.CalculateTotalOfOrder(id);
        }
    }
}

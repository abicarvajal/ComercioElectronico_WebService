using Course.ComercioElectronico.Aplicacion.DTOs;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface ICalculationAppService
    {
        /// <summary>
        /// Calculate total of order by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DetailOrderDto> CalculateTotalOfOrder(string id);
    }
}

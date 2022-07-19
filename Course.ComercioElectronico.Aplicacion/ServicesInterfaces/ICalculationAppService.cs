using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface ICalculationAppService
    {
        /// <summary>
        /// Calculate total of order by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<decimal> CalculateTotalOfOrder(string id);
    }
}

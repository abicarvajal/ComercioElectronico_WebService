using Course.ComercioElectronico.Aplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Aplicacion.ServicesInterfaces
{
    public interface IDeliveryMethodAppService
    {
        Task<ICollection<DeliveryMethodDto>> GetAllAsync();
        Task<DeliveryMethodDto> GetByIdDtoAsync(string id);
        Task<DeliveryMethodDto> UpdateAsync(DeliveryMethodDto deliveryMethod);
        Task<bool> Delete(string id);
        Task<DeliveryMethodDto> CreateAsync(CreateDeliveryMethodDto deliveryMethod);
    }
}

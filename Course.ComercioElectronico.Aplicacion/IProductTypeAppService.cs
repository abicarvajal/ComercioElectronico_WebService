using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IProductTypeAppService
    {
        Task<ICollection<ProductType>> GetAsync();
        Task<ProductType> GetByIdAsync(string code);
        Task<ProductType> UpdateAsync(ProductType productType);
        Task<bool> Delete(ProductType productType);
        Task<ProductType> CreateAsync(ProductType productType);
    }
}
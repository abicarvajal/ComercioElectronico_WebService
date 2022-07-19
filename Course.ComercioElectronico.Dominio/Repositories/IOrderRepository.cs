using Course.ComercioElectronico.Dominio.Entities;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<CartOrder> GetQueryable();
        IQueryable<CartItemOrder> GetQueryableItems();
        Task CreateCartOrderAsync(CartOrder cartOrder);
        Task CreateCartItemOrderAsync(CartItemOrder cartItemOrder);
        Task UpdateCartOrder(CartOrder cartOrder);
        Task UpdateCartItemOrder(CartItemOrder cartItemOrder);
    }
}
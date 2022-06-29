using Course.ComercioElectronico.Dominio;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface IClienteAplicacion
    {
        Task<ICollection<Cliente>> ObtenerPorCodigoAsync(string codigo);
    }
}
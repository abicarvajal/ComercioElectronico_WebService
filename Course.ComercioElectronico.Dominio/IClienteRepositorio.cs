using Course.ComercioElectronico.Dominio;

namespace Course.ComercioElectronico.Infraestructura
{
    public interface IClienteRepositorio
    {
        Task<ICollection<Cliente>> ObtenerPorCodigoAsync(string code);
    }
}
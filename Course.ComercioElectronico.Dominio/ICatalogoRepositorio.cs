using Course.ComercioElectronico.Dominio;

namespace Course.ComercioElectronico.Infraestructura
{
    public interface ICatalogoRepositorio
    {
        Task<ICollection<Catalogo>> ObtenerAsync();
    }
}
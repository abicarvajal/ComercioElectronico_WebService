using Course.ComercioElectronico.Dominio;

namespace Course.ComercioElectronico.Aplicacion
{
    public interface ICatalogoAplicacion
    {
        Task<ICollection<Catalogo>> ObtenerAsync();
    }
}
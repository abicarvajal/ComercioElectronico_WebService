using Course.ComercioElectronico.Dominio;
using Course.ComercioElectronico.Infraestructura;

namespace Course.ComercioElectronico.Aplicacion
{
    //Servicio de aplicacion para los catalogos de productos 
    public class CatalogoAplicacion : ICatalogoAplicacion
    {
        protected ICatalogoRepositorio CatalogoRepositorio { get; set; }
        

        public CatalogoAplicacion(ICatalogoRepositorio repositorio)
        {
            this.CatalogoRepositorio = repositorio;
            
        }

        public Task<ICollection<Catalogo>> ObtenerAsync()
        {
            return CatalogoRepositorio.ObtenerAsync();
        }
    }
}
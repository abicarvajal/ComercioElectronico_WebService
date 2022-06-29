using Course.ComercioElectronico.Dominio;
using Course.ComercioElectronico.Infraestructura;

namespace Course.ComercioElectronico.Aplicacion
{
    public class ClienteAplicacion : IClienteAplicacion
    {
        protected IClienteRepositorio ClienteRepositorio { get; set; }

        public ClienteAplicacion(IClienteRepositorio clienteRepositorio)
        {
            ClienteRepositorio = clienteRepositorio;
        }

        public Task<ICollection<Cliente>> ObtenerPorCodigoAsync(string codigo)
        {
            return ClienteRepositorio.ObtenerPorCodigoAsync(codigo);
        }

    }
}

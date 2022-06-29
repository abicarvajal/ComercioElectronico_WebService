using Course.ComercioElectronico.Dominio;

namespace Course.ComercioElectronico.Infraestructura
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public async Task<ICollection<Cliente>> ObtenerPorCodigoAsync(string code)
        {
            var lista = new List<Cliente> { new Cliente { Codigo = "Foo", Nombre = "bar" } };
            //lista.Add(new Cliente { Codigo = "Foo", Nombre = "bar" });
            return await Task.FromResult(lista);
        }

    }
}

using Course.ComercioElectronico.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Course.ComercioElectronico.Infraestructura
{
    public class CatalogoRepositorio : ICatalogoRepositorio
    {
        private readonly ComercioElectronicoDBContext context;

        public CatalogoRepositorio(ComercioElectronicoDBContext context)
        {
            //context = new ComercioElectronicoDBContext();
            this.context = context;
        }
        public async Task<ICollection<Catalogo>> ObtenerAsync()
        {
            //var lista = new List<Catalogo> { new Catalogo { Codigo = "Foo", Nombre = "bar" } };
            //lista.Add( new Catalogo { Codigo = "Foo", Nombre = "bar" });
            //return await Task.FromResult(lista);
            return await context.Catalogo.ToListAsync();
        }
    }
}
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ComercioElectronicoDBContext context;

        public ProductRepository(ComercioElectronicoDBContext context)
        {
            //context = new ComercioElectronicoDBContext();
            this.context = context;
        }
        public async Task<ICollection<Product>> GetAsync()
        {
            //var lista = new List<Catalogo> { new Catalogo { Codigo = "Foo", Nombre = "bar" } };
            //lista.Add( new Catalogo { Codigo = "Foo", Nombre = "bar" });
            //return await Task.FromResult(lista);
            return await context.Product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await context.Product.FindAsync(id);
        }
    }
}

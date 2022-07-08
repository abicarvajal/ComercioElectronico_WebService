using Course.ComercioElectronico.Dominio.Entities.Base;
using Course.ComercioElectronico.Dominio.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ComercioElectronicoDBContext context;

        public GenericRepository(ComercioElectronicoDBContext context)
        {
            this.context = context;
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string code)
        {
            return await context.Set<T>().FindAsync(code);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return context.Set<T>().AsQueryable();
        }

        //public async Task<ResultPagination<T>> GetListAsync(string search = "",int limit = 10, int offset = 0, string sort = "Name", string order = "asc")
        //{
        //    var query = GetQueryable();
        //    //Filtrando los eliminados
        //    query = query.Where(x => x.IsDeleted == false);
        //    //1. Total
        //    var total = await query.CountAsync();
        //    //2. Pagination
        //    query = query
        //        .Skip(offset)
        //        .Take(limit);
        //    //3. Order
        //    //if (!string.IsNullOrEmpty(sort))
        //    //{
        //    //    switch (sort.ToUpper())
        //    //    {
        //    //        case "Name":
        //    //            query = query.OrderBy(x => x.Name);
        //    //            break;
        //    //        case "Price":
        //    //            query = query.OrderBy(x => x.Price);
        //    //            break;
        //    //        default:
        //    //            throw new ArgumentException($"The parameter sort {sort} not support");
        //    //            break;
        //    //    }
        //    //}

        //    //return await context.Set<T>()
        //    //    .Take(limit)
        //    //    .Skip(offset)
        //    //    .ToListAsync();
        //    var result = new ResultPagination<T>();
        //    result.Total = total;
            
        //    return result;
        //}
    }
}

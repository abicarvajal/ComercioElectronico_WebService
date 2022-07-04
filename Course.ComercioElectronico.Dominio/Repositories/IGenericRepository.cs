using Course.ComercioElectronico.Dominio.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Dominio.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all objects of an entity
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAsync();

        /// <summary>
        /// Get an object by string ID
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string code);

        /// <summary>
        /// Get an object by Guid ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Delete an object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(T entity);

        /// <summary>
        /// Update an object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Create an object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);

        /// <summary>
        /// Get a query to use and implement filters
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();
    }
    
}

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
        /// Listar todos los objetos de la entidad
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAsync();

        /// <summary>
        /// Obtener el objeto enviando un ID de tipo string
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string code);

        /// <summary>
        /// Obtener el objeto enviando un ID de tipo Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);

        Task Delete(T entity);

        Task UpdateAsync(T entity);

        Task CreateAsync(T entity);
    }
    
}

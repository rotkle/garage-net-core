using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>Entities.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get entity by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="includeProperties">Lets the caller provide an array of properties for eager loading.</param>
        /// <returns>Entity.</returns>
        TEntity GetById(
            object id,
            Expression<Func<TEntity, object>>[] includeProperties = null);

        /// <summary>
        /// Insert entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete entity.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Delete(TEntity entity);
    }
}

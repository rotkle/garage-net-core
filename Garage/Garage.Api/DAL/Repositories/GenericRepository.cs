using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garage.Api.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">Object context.</param>
        public GenericRepository(DbContext context)
        {
            this.CurrentContext = context;
            this.dbset = this.CurrentContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets or sets current context.
        /// </summary>
        public DbContext CurrentContext { get; set; }

        /// <inheritdoc/>
        public virtual IQueryable<TEntity> GetAll()
        {
            return this.dbset.AsQueryable();
        }

        /// <inheritdoc/>
        public virtual TEntity GetById(object id, Expression<Func<TEntity, object>>[] includeProperties = null)
        {
            DbSet<TEntity> query = this.dbset;

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => (DbSet<TEntity>)current.Include(include));
            }

            return query.Find(id);
        }

        /// <inheritdoc/>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.dbset.Add(entity);
        }

        /// <inheritdoc/>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            this.dbset.Attach(entity);
            this.CurrentContext.Update<TEntity>(entity);
        }

        /// <inheritdoc/>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (this.CurrentContext.Entry(entity).State == EntityState.Detached)
            {
                this.dbset.Attach(entity);
            }

            this.dbset.Remove(entity);
        }
    }
}

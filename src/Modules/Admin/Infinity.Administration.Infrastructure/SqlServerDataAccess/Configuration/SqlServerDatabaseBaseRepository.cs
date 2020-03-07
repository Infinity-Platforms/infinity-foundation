namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration
{
    using Infinity.Administration.Domain.Base;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="SqlServerDatabaseBaseRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class SqlServerDatabaseBaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Defines the context
        /// </summary>
        internal SqlDataContext context;

        /// <summary>
        /// Defines the dbSet
        /// </summary>
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDatabaseBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="SqlDataContext"/></param>
        public SqlServerDatabaseBaseRepository(SqlDataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="entityToDelete">The entityToDelete<see cref="TEntity"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Delete(TEntity entityToDelete)
        {
            await Task.Run(() =>
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            });
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/></param>
        /// <param name="orderBy">The orderBy<see cref="Func{IQueryable{TEntity}, IOrderedQueryable{TEntity}}"/></param>
        /// <param name="includeProperties">The includeProperties<see cref="string"/></param>
        /// <returns>The <see cref="Task{IEnumerable{TEntity}}"/></returns>
        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="object"/></param>
        /// <returns>The <see cref="Task{TEntity}"/></returns>
        public async virtual Task<TEntity> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="entityToUpdate">The entityToUpdate<see cref="TEntity"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Update(TEntity entityToUpdate)
        {
            await Task.Run(() =>
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            });
        }
    }
}

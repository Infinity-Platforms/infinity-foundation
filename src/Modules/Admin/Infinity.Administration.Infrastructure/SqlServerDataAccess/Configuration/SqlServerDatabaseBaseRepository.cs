namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration
{
    using Infinity.Administration.Domain.Base;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Defines the <see cref="SqlServerDatabaseBaseRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class SqlServerDatabaseBaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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

        //public virtual IEnumerable<TEntity> GetWithRawSql(string query,
        //    params object[] parameters)
        //{
        //    return dbSet.SqlQuery(query, parameters).ToList();
        //}
        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/></param>
        /// <param name="orderBy">The orderBy<see cref="Func{IQueryable{TEntity}, IOrderedQueryable{TEntity}}"/></param>
        /// <param name="includeProperties">The includeProperties<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{TEntity}"/></returns>
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
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
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// The GetByID
        /// </summary>
        /// <param name="id">The id<see cref="object"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="object"/></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="entityToDelete">The entityToDelete<see cref="TEntity"/></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="entityToUpdate">The entityToUpdate<see cref="TEntity"/></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

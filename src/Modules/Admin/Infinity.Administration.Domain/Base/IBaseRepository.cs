namespace Infinity.Administration.Domain.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IRepository{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="entityToDelete">The entityToDelete<see cref="TEntity"/></param>
        Task Delete(TEntity entityToDelete);
         
        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="filter">The filter<see cref="Expression{Func{TEntity, bool}}"/></param>
        /// <param name="orderBy">The orderBy<see cref="Func{IQueryable{TEntity}, IOrderedQueryable{TEntity}}"/></param>
        /// <param name="includeProperties">The includeProperties<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{TEntity}"/></returns>
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// The GetByID
        /// </summary>
        /// <param name="id">The id<see cref="object"/></param>
        /// <returns>The <see cref="TEntity"/></returns>
        Task<TEntity> GetById(object id);

        /// <summary>
        /// The GetWithRawSql
        /// </summary>
        /// <param name="query">The query<see cref="string"/></param>
        /// <param name="parameters">The parameters<see cref="object[]"/></param>
        /// <returns>The <see cref="IEnumerable{TEntity}"/></returns>
        //IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        Task Insert(TEntity entity);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="entityToUpdate">The entityToUpdate<see cref="TEntity"/></param>
        Task Update(TEntity entityToUpdate);
    }
}

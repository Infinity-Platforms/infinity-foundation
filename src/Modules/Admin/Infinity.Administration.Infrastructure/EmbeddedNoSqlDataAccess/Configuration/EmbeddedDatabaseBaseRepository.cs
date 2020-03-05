namespace Infinity.Administration.Infrastructure.EmbeddedDataAccess.Configuration
{
    using Infinity.Administration.Domain.Base;
    using LiteDB;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="EmbeddedDatabaseBaseRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmbeddedDatabaseBaseRepository<T> where T: IBaseEntity
    {
        /// <summary>
        /// Defines the embeddedDatabaseContext
        /// </summary>
        private readonly EmbeddedDatabaseContext embeddedDatabaseContext;

        /// <summary>
        /// Defines the _collectionName
        /// </summary>
        private readonly string _collectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedDatabaseBaseRepository{T}"/> class.
        /// </summary>
        /// <param name="collectionName">The collectionName<see cref="string"/></param>
        /// <param name="embeddedDatabaseContext">The embeddedDatabaseContext<see cref="EmbeddedDatabaseContext"/></param>
        public EmbeddedDatabaseBaseRepository(string collectionName, EmbeddedDatabaseContext embeddedDatabaseContext)
        {
            _collectionName = collectionName;
            this.embeddedDatabaseContext = embeddedDatabaseContext;
        }

        /// <summary>
        /// Get single document
        /// </summary>
        /// <param name="expression">The expression<see cref="System.Linq.Expressions.Expression{Func{T, bool}}"/></param>
        /// <returns>The <see cref="Task{T}"/></returns>
        public async Task<T> GetById(int id)
        {
            var output = default(T);

            await Task.Run(() =>
            {
                using (var db = new LiteRepository(embeddedDatabaseContext.ConnectionString))
                {
                    output = db.Query<T>().Where(x => x.Id == id).FirstOrDefault();
                }

            });

            return output;
        }

        /// <summary>
        /// Finds the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public async Task<List<T>> FindAll(Expression<Func<T, bool>> expression)
        {
            List<T> output = null;

            await Task.Run(() =>
            {
                using (var db = new LiteRepository(embeddedDatabaseContext.ConnectionString))
                {
                    output = db.Query<T>().Where(expression).ToList();
                }
            });

            return output;
        }


        public async Task<int> Create(T input)
        {
            int output = 0;

            using (var db = new LiteDatabase(embeddedDatabaseContext.ConnectionString))
            {
                //var col = db.Database.GetCollection<T>(_collectionName);
                //col.Insert(input.Id, input);
                var col = db.GetCollection<T>(_collectionName);
                col.Insert(input);
                //db.Insert<T>(input, _collectionName);
                output = 1;
            }

            return await Task.FromResult(output);
        }

        public async Task<int> Update(int id, T input)
        {
            int output = 0;

            using (var db = new LiteRepository(embeddedDatabaseContext.ConnectionString))
            {
                var col = db.Database.GetCollection<T>(_collectionName);
                col.Update(input);
                output = 1;
            }

            return await Task.FromResult(output);
        }

        public IQueryable<T> FindAllAsQueryable(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

    }
}

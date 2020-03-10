namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration
{
    using Infinity.Administration.Infrastructure.SqlServerDataAccess.Entities;
    using Infinity.Shared.Domain.Persistence;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="SqlDataContext" />
    /// </summary>
    public class SqlDataContext : DbContext
    {
        private readonly PersistenceSettings _persistenceSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{SqlDataContext}"/></param>
        public SqlDataContext(DbContextOptions<SqlDataContext> options, PersistenceSettings persistenceSettings) : base(options)
        {
            _persistenceSettings = persistenceSettings;
        }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public DbSet<User> Users { get; set; } = null;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_persistenceSettings.SqlDbConnectionString);
        }
    }
}

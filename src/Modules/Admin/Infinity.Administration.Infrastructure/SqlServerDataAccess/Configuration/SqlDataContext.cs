namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="SqlDataContext" />
    /// </summary>
    public class SqlDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{SqlDataContext}"/></param>
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        
    }
}

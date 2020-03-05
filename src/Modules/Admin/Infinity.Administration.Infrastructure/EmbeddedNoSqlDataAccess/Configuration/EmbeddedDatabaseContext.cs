namespace Infinity.Administration.Infrastructure.EmbeddedDataAccess.Configuration
{
    public class EmbeddedDatabaseContext
    {
        public string ConnectionString { get; set; }

        public EmbeddedDatabaseContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}

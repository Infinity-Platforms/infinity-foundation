namespace Infinity.Administration.Api.Extensions
{
    using Infinity.Administration.Domain.Users;
    using Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration;
    using Infinity.Shared.Domain.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="PersitenceExtensions" />
    /// </summary>
    public static class PersitenceExtensions
    {
        /// <summary>
        /// The AddPersistence
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("PersistenceModule:UseFake");

            var persistenceSettings = new PersistenceSettings { 
                SqlDbConnectionString = configuration.GetValue<string>("ConnectionStrings:SqlDb"),
                NoSqlDbConnectionString = configuration.GetValue<string>("ConnectionStrings:EmbeddedDb")
            };

            services.AddSingleton<PersistenceSettings>(persistenceSettings);
            services.AddDbContext<SqlDataContext>(x => x.UseSqlServer(persistenceSettings.SqlDbConnectionString));
            services.AddScoped<IUserRepository, Infrastructure.SqlServerDataAccess.Repositories.UserRepository>();
             
            return services;
        }
    }
}

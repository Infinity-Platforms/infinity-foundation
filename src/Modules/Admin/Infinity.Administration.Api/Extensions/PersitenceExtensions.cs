namespace Infinity.Administration.Api.Extensions
{
    using Infinity.Administration.Domain.Users;
    using Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration;
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
            string embeddedDbConnectionString = configuration.GetValue<string>("ConnectionStrings:EmbeddedDb");

            services.AddDbContext<SqlDataContext>(x => x.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:EmbeddedDb")));

            //if (useFake)
            //{
            //    services.AddSingleton<EmbeddedDatabaseContext>(new EmbeddedDatabaseContext(embeddedDbConnectionString));
            //    services.AddScoped<IUserRepository, Infrastructure.EmbeddedDataAccess.Repositories.UserRepository>();
            //}
            //else
            //{
            //    services.AddSingleton<EmbeddedDatabaseContext>(new EmbeddedDatabaseContext(embeddedDbConnectionString));
            //    services.AddScoped<IUserRepository, Infrastructure.EmbeddedDataAccess.Repositories.UserRepository>();
            //}

            return services;
        }
    }
}

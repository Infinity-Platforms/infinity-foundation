namespace Infinity.Administration.Api.Extensions
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="LoggingExtensions" />
    /// </summary>
    public static class LoggingExtensions
    {
        /// <summary>
        /// The AddLogging
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddLogging(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            return services;
        }
    }
}

namespace Infinity.Administration.Api.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="ApplicationExtensions" />
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.UserDetails.IUseCase, Application.UseCases.GetUserDetailsUseCase>();
            services.AddScoped<Application.Boundaries.RegisterNewUser.IUseCase, Application.UseCases.RegisterNewUserUseCase>();

            //services.AddScoped<AccountService>();

            return services;
        }
    }
}

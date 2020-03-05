namespace Infinity.Administration.Api.Extensions
{
    using Infinity.Administration.Api.Controllers.V1.RegisterUser;
    using Infinity.Administration.Api.Controllers.V1.UserDetails;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="UserInterfaceV1Extensions" />
    /// </summary>
    public static class UserInterfaceV1Extensions
    {
        /// <summary>
        /// The AddPresenterV1
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddPresenterV1(
            this IServiceCollection services)
        {

            services.AddScoped<UserDetailsPresenter, UserDetailsPresenter>();
            services.AddScoped<Application.Boundaries.UserDetails.IOutputPort>(x =>
                x.GetRequiredService<UserDetailsPresenter>());

            services.AddScoped<RegisterUserPresenter, RegisterUserPresenter>();
            services.AddScoped<Application.Boundaries.RegisterNewUser.IOutputPort>(x =>
                x.GetRequiredService<RegisterUserPresenter>());

            return services;
        }
    }
}

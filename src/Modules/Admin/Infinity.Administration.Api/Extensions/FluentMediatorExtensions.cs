namespace Infinity.Administration.Api.Extensions
{
    using FluentMediator;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="FluentMediatorExtensions" />
    /// </summary>
    public static class FluentMediatorExtensions
    {
        /// <summary>
        /// The AddMediator
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<Application.Boundaries.UserDetails.UserDetailsInput>().PipelineAsync()
                        .Call<Application.Boundaries.UserDetails.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<Application.Boundaries.RegisterNewUser.RegisterUserInput>().PipelineAsync()
                        .Call<Application.Boundaries.RegisterNewUser.IUseCase>((handler, request) => handler.Execute(request));
                });

            return services;
        }
    }
}

namespace AlightApp.Application
{
    using System.Reflection;
    using AlightApp.Application.Commands.Users;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    public static class DependencyInjection
    {
        /// <summary>
        /// Register this method in the startup 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());  // Register all validator within the assembly
            services.AddMediatR(Assembly.GetExecutingAssembly());  // Register all requests
            return services;
        }
    }
}

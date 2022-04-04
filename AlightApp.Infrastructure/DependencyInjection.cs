namespace AlightApp.Infrastructure
{
    using AlightApp.Application.Interfaces;
    using AlightApp.Infrastructure.Adapters;
    using AlightApp.Infrastructure.External.Files;
    using AlightApp.Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;
    public static class DependencyInjection
    {
        /// <summary>
        /// Register this method in the startup
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IUserAdapter, UserAdapter>();
            services.AddTransient<IFileHandlerService, SharedFileHandlerService>();

            return services;
        }
    }
}

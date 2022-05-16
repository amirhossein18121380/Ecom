using System.Diagnostics;

namespace Ecom.Common.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services, configuration);
            }
            return ServiceTool.Create(services);
        }
    }

    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection, IConfiguration configuration);
    }

    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }

    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}

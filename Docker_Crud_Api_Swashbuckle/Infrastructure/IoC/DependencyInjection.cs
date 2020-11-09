using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Concrete;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Concrete;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace Docker_Crud_Api_Swashbuckle.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IConfiguration Configuration { get; }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.Configure<CatalogDbSettings>(Configuration.GetSection(nameof(CatalogDbSettings)));

            services.AddSingleton<ICatalogDbSettings>(options => options.GetRequiredService<IOptions<CatalogDbSettings>>().Value);

            services.AddTransient<IProjectContext, ProjectContext>();

            return services;
        }
    }
}

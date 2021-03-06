﻿using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Concrete;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Repositories.Concrete;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Repositories.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Concrete;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            

            services.AddSingleton<ICatalogDbSettings>(options => options.GetRequiredService<IOptions<CatalogDbSettings>>().Value);

            services.AddScoped<IProjectContext, ProjectContext>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Catalog API", Version = "v1" });
            });

            return services;
        }
    }
}

using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Concrete
{
    public class ProjectContext : IProjectContext
    {
        public ProjectContext(ICatalogDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Products = database.GetCollection<Product>
                                        (settings.CollectionName);

            //Seeding operasyonunu yap
            ProductSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}

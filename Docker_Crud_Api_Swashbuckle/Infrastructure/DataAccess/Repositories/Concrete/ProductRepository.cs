using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Repositories.Interfaces;
using Docker_Crud_Api_Swashbuckle.Infrastructure.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProjectContext _context;

        public ProductRepository(IProjectContext context)=> _context = context ?? throw new ArgumentNullException(nameof(context));


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter =
                    Builders<Product>.Filter.ElemMatch(p => p.Name, name);

            return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>>
                            GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter =
                    Builders<Product>.Filter.ElemMatch
                            (p => p.Category, categoryName);

            return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }


        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context
                                        .Products
                                        .ReplaceOneAsync(
                                            filter: g => g.Id == product.Id,
                                            replacement: product);

            return updateResult.IsAcknowledged
                        && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter =
                        Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
        }
    }
}

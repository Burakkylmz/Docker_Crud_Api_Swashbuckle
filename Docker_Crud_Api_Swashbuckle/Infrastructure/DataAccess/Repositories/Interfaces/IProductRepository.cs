using Docker_Crud_Api_Swashbuckle.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        Task Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}

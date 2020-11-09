using Docker_Crud_Api_Swashbuckle.Infrastructure.Entities;
using MongoDB.Driver;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Context.Interfaces
{
    public interface IProjectContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

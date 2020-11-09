using Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Interfaces;


namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Concrete
{
    public class CatalogDbSettings : ICatalogDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}

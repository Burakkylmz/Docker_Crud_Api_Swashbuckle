using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.DataAccess.Settings.Interfaces
{
    public interface ICatalogDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CollectionName { get; set; }
    }
}

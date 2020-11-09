using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Docker_Crud_Api_Swashbuckle.Infrastructure.Entities
{
    public class Product
    {
        [BsonId] //MongoDB.Bson paketini yükle
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}

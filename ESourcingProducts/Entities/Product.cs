using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcingProducts.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("Name:")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public string Price { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Response
{
    public class BrandResponseDto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String Id { get; set; }
        public string Name { get; set; }
    }
}

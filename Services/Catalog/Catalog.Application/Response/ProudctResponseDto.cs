using Catalog.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Response
{
    public class ProudctResponseDto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public String Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }

        public string ImageFile { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Price { get; set; }


        public ProudctBrand Brand { get; set; }

        public ProudctType Type { get; set; }
    }
}

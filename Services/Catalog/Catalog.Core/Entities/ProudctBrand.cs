using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities
{
    public class ProudctBrand : BaseEntity
    {

        public string Name { get; set; }
    }

}
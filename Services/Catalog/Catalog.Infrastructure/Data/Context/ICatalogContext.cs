using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context
{
    public interface ICatalogContext
    {
        IMongoCollection<Proudct> Proudcts { get; }
        IMongoCollection<ProudctBrand> Brands { get; }
        IMongoCollection<ProudctType> Types { get; }


    }
}

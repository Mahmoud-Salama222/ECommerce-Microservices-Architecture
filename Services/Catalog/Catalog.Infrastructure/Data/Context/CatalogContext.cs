using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data.Context
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Proudct> Proudcts { get; }

        public IMongoCollection<ProudctBrand> Brands { get; }

        public IMongoCollection<ProudctType> Types { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSetting:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSetting:DatabaseName"]);

            Proudcts = database.GetCollection<Proudct>(configuration["DatabaseSetting:ProductsCollection"]);
            Brands = database.GetCollection<ProudctBrand>(configuration["DatabaseSetting:BrandsCollection"]);
            Types = database.GetCollection<ProudctType>(configuration["DatabaseSetting:TypesCollection"]);

            _ = CatalogSeeder.SeedFromFileAsync(Proudcts, "Catalog.json");
            _ = CatalogSeeder.SeedFromFileAsync(Brands, "Brands.json");
            _ = CatalogSeeder.SeedFromFileAsync(Types, "Types.json");


        }
    }
}

using Catalog.Core.Entities;
using Catalog.Core.Paganation;
using Catalog.Core.Repositries;
using Catalog.Core.Spec;
using Catalog.Infrastructure.Data.Context;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositries
{
    public class ProudctRepositry : IProudctRepositories, IBrandRepository, ITypeRepository
    {
        public ICatalogContext _catalogContext { get; set; }
        public ProudctRepositry(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }
        public async Task<Proudct> GetProudctById(string Id)
        {
            return await _catalogContext.Proudcts.Find(p => p.Id == Id).FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<Proudct>> GetAllProudcts()
        {
            return await _catalogContext.Proudcts.Find(p => true).ToListAsync();

        }
        public async Task<Paganation<Proudct>> GetAllProudctsWithSpecParams(CatalogSpecParams catalogSpecParams)
        {
            //return await _catalogContext.proudcts.Find(p => true).ToListAsync();
            var filterBuilder = Builders<Proudct>.Filter;
            var filter = filterBuilder.Empty;
            if (!string.IsNullOrEmpty(catalogSpecParams.BrandId))
            {
                filter &= filterBuilder.Eq(p => p.Brand.Id, catalogSpecParams.BrandId);
            }

            // ✅ فلترة حسب Type
            if (!string.IsNullOrEmpty(catalogSpecParams.TypeId))
            {
                filter &= filterBuilder.Eq(p => p.Type.Id, catalogSpecParams.TypeId);
            }

            if (!string.IsNullOrEmpty(catalogSpecParams.Search))
            {
                filter &= filterBuilder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(catalogSpecParams.Search, "i"));
            }


            var sortBuilder = Builders<Proudct>.Sort;


            var sort = sortBuilder.Ascending(p => p.Name); // Default Sort

            if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
            {
                sort = catalogSpecParams.Sort switch
                {
                    "priceAsc" => sortBuilder.Ascending(p => p.Price),
                    "priceDesc" => sortBuilder.Descending(p => p.Price),
                    _ => sort
                };
            }

            // ✅ Apply Pagination
            var skip = (catalogSpecParams.PageIndex - 1) * catalogSpecParams.PageSize;

            var products = await _catalogContext.Proudcts
                .Find(filter)
                .Sort(sort)
                .Skip(skip)
                .Limit(catalogSpecParams.PageSize)
                .ToListAsync();
            var paganationOfProudct = new Paganation<Proudct>(catalogSpecParams.PageIndex, catalogSpecParams.PageSize, products.Count(), products);

            return paganationOfProudct;

        }
        public async Task<Proudct> CreateProudct(Proudct proudct)
        {
            await _catalogContext.Proudcts.InsertOneAsync(proudct);
            return proudct;
        }

        public async Task<bool> DeleteProudct(string Id)
        {
            var deleteproudct = await _catalogContext.Proudcts.DeleteOneAsync(p => p.Id == Id);
            return deleteproudct.IsAcknowledged && deleteproudct.DeletedCount > 0; //mondo db understand reuqest and make it



        }

        public async Task<IEnumerable<ProudctBrand>> GetAllBrands()
        {
            return await _catalogContext.Brands.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Proudct>> GetAllProudctByBrand(string Name)
        {
            return await _catalogContext.Proudcts.Find(p => p.Brand.Name == Name).ToListAsync();
        }

        public async Task<IEnumerable<Proudct>> GetAllProudctByName(string Name)
        {
            return await _catalogContext.Proudcts.Find(p => p.Name == Name).ToListAsync();
        }

        public async Task<IEnumerable<ProudctType>> GetAllTypes()
        {
            return await _catalogContext.Types.Find(p => true).ToListAsync();
        }


        public async Task<bool> UpdateProudct(Proudct proudct)
        {

            var updatedprooudct = await _catalogContext.Proudcts.ReplaceOneAsync(p => p.Id == proudct.Id, proudct);
            return updatedprooudct.IsAcknowledged && updatedprooudct.ModifiedCount > 0; //mondo db understand reuqest and make it


        }

    }
}

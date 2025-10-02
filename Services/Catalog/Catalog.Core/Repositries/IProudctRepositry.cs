using Catalog.Core.Entities;
using Catalog.Core.Paganation;
using Catalog.Core.Spec;

namespace Catalog.Core.Repositries
{
    public interface IProudctRepositories
    {
        Task<IEnumerable<Proudct>> GetAllProudcts();
        Task<Paganation<Proudct>> GetAllProudctsWithSpecParams(CatalogSpecParams catalogSpecParams);

        Task<Proudct> GetProudctById(string Id);

        Task<IEnumerable<Proudct>> GetAllProudctByName(string Name);

        Task<IEnumerable<Proudct>> GetAllProudctByBrand(string Name);
        Task<Proudct> CreateProudct(Proudct proudct);
        Task<bool> UpdateProudct(Proudct proudct);

        Task<bool> DeleteProudct(String Id);
    }
}

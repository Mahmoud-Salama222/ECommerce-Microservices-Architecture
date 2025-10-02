using Catalog.Core.Entities;

namespace Catalog.Core.Repositries
{
    public interface IBrandRepository
    {
        Task<IEnumerable<ProudctBrand>> GetAllBrands();

    }
}

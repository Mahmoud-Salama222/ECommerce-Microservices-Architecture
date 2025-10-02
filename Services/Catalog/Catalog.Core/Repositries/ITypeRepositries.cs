using Catalog.Core.Entities;

namespace Catalog.Core.Repositries
{
    public interface ITypeRepository
    {

        Task<IEnumerable<ProudctType>> GetAllTypes();










    }
}

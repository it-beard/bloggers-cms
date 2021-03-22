using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IContentRepository : IRepositoryBase<Content>
    {
        Task<List<Content>> GetAllWithOrdersAsync();
    }
}
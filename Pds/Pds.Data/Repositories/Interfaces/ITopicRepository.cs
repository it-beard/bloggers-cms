using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces
{
    public interface ITopicRepository : IRepositoryBase<Topic>
    {
        Task<Topic> GetFirstWithPeople(Expression<Func<Topic, bool>> match);
    }
}
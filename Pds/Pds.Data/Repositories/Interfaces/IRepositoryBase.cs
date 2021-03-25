using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pds.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<List<TEntity>> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<List<TEntity>> FindAllByWhereOrderedAscendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);

        Task<List<TEntity>> FindAllByWhereOrderedDescendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);

        Task<List<TEntity>> GetAllAsync();

        Task<IList<TEntity>> UpdateRangeAsync(IList<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<IList<TEntity>> InsertRangeAsync(IList<TEntity> entities, bool saveChanges = true);

        Task Delete(TEntity entity);

        Task DeleteRange(ICollection<TEntity> entities);

        Task<int> Count();

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> match);
    }
}
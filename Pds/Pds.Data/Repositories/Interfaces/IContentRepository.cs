﻿using System.Linq.Expressions;
using Pds.Data.Entities;

namespace Pds.Data.Repositories.Interfaces;

public interface IContentRepository : IRepositoryBase<Content>
{
    Task<List<Content>> GetAllFullAsync();
    Task<Content> GetFullByIdAsync(Guid contentId);
    Task<Content> GetByIdWithBillAsync(Guid contentId);
    Task<Content> GetByIdWithBillWithCostsAsync(Guid contentId);
    Task<List<Content>> GetContentsForListByBrandId(Guid brandId);
    Task<Content> FullUpdateAsync(Content content);
    Task FullDeleteAsync(Content content);
    Task FullArchiveAsync(Content content);
    Task<Content> GetFirstOrderByReleaseDateWhereAsync(Expression<Func<Content, bool>> match);
    Task<List<Content>> FindAllOrderByReleaseDateWhereAsync(Expression<Func<Content, bool>> match);
}
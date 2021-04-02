using System;
using System.Threading.Tasks;
using Pds.Data;
using Pds.Data.Entities;

namespace Pds.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Guid> CreateAsync(Topic topic);
    }
}
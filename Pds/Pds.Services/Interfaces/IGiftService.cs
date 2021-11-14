using Pds.Data.Entities;
using Pds.Services.Models.Bill;
namespace Pds.Services.Interfaces;

public interface IGiftService
{
    Task<List<Gift>> GetAllAsync();
}
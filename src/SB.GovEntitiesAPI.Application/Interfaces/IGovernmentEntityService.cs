using SB.GovEntitiesAPI.Application.DTOs;

namespace SB.GovEntitiesAPI.Application.Interfaces
{
    public interface IGovernmentEntityService
    {
        Task<IEnumerable<GovernmentEntityDto>> GetAllAsync();
        Task<GovernmentEntityDto> GetByIdAsync(int id);
        Task<int> CreateAsync(GovernmentEntityDto entityDto);
        Task UpdateAsync(int id, GovernmentEntityDto entityDto);
        Task DeleteAsync(int id);
    }
}
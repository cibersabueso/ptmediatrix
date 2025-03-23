using SB.GovEntitiesAPI.Domain.Entities;

namespace SB.GovEntitiesAPI.Application.Interfaces
{
    public interface IGovernmentEntityRepository
    {
        Task<IEnumerable<GovernmentEntity>> GetAllAsync();
        Task<GovernmentEntity> GetByIdAsync(int id);
        Task<int> AddAsync(GovernmentEntity entity);
        Task UpdateAsync(GovernmentEntity entity);
        Task DeleteAsync(int id);
    }
}
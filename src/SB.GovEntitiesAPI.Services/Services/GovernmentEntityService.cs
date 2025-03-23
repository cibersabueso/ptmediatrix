using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SB.GovEntitiesAPI.Application.DTOs;
using SB.GovEntitiesAPI.Application.Interfaces;
using SB.GovEntitiesAPI.Domain.Entities;

namespace SB.GovEntitiesAPI.Services.Services
{
    public class GovernmentEntityService : IGovernmentEntityService
    {
        private readonly IGovernmentEntityRepository _repository;
        private readonly ILogger<GovernmentEntityService> _logger;

        public GovernmentEntityService(IGovernmentEntityRepository repository, ILogger<GovernmentEntityService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<GovernmentEntityDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e));
        }

        public async Task<GovernmentEntityDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found");
            }
            
            return MapToDto(entity);
        }

        public async Task<int> CreateAsync(GovernmentEntityDto entityDto)
        {
            var entity = MapToEntity(entityDto);
            return await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, GovernmentEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found");
            }
            
            var entity = MapToEntity(entityDto);
            entity.Id = id;
            
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        private GovernmentEntityDto MapToDto(GovernmentEntity entity)
        {
            return new GovernmentEntityDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Acronym = entity.Acronym,
                Description = entity.Description,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                Website = entity.Website,
                IsActive = entity.IsActive
            };
        }

        private GovernmentEntity MapToEntity(GovernmentEntityDto dto)
        {
            return new GovernmentEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Acronym = dto.Acronym,
                Description = dto.Description,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Website = dto.Website,
                IsActive = dto.IsActive
            };
        }
    }
}
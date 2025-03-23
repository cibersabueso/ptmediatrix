using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SB.GovEntitiesAPI.Application.Interfaces;
using SB.GovEntitiesAPI.Domain.Entities;

namespace SB.GovEntitiesAPI.Infrastructure.Repositories
{
    public class GovernmentEntityRepository : IGovernmentEntityRepository
    {
        private readonly string _dataFilePath;
        private readonly ILogger<GovernmentEntityRepository> _logger;

        public GovernmentEntityRepository(IConfiguration configuration, ILogger<GovernmentEntityRepository> logger)
        {
            _dataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "government_entities.json");
            _logger = logger;
            
            Directory.CreateDirectory(Path.GetDirectoryName(_dataFilePath));
            
            if (!File.Exists(_dataFilePath))
            {
                File.WriteAllText(_dataFilePath, JsonSerializer.Serialize(new List<GovernmentEntity>()));
            }
        }

        private async Task<List<GovernmentEntity>> ReadAllFromFileAsync()
        {
            try
            {
                var json = await File.ReadAllTextAsync(_dataFilePath);
                return JsonSerializer.Deserialize<List<GovernmentEntity>>(json) ?? new List<GovernmentEntity>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading from file");
                return new List<GovernmentEntity>();
            }
        }

        private async Task WriteAllToFileAsync(List<GovernmentEntity> entities)
        {
            try
            {
                var json = JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(_dataFilePath, json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error writing to file");
                throw;
            }
        }

        public async Task<IEnumerable<GovernmentEntity>> GetAllAsync()
        {
            return await ReadAllFromFileAsync();
        }

        public async Task<GovernmentEntity> GetByIdAsync(int id)
        {
            var entities = await ReadAllFromFileAsync();
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public async Task<int> AddAsync(GovernmentEntity entity)
        {
            var entities = await ReadAllFromFileAsync();
            
            if (entity.Id == 0)
            {
                entity.Id = entities.Count > 0 ? entities.Max(e => e.Id) + 1 : 1;
            }
            
            entity.CreatedAt = DateTime.Now;
            entities.Add(entity);
            
            await WriteAllToFileAsync(entities);
            return entity.Id;
        }

        public async Task UpdateAsync(GovernmentEntity entity)
        {
            var entities = await ReadAllFromFileAsync();
            var existingEntity = entities.FirstOrDefault(e => e.Id == entity.Id);
            
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {entity.Id} not found");
            }
            
            existingEntity.Name = entity.Name;
            existingEntity.Acronym = entity.Acronym;
            existingEntity.Description = entity.Description;
            existingEntity.Address = entity.Address;
            existingEntity.PhoneNumber = entity.PhoneNumber;
            existingEntity.Email = entity.Email;
            existingEntity.Website = entity.Website;
            existingEntity.IsActive = entity.IsActive;
            existingEntity.UpdatedAt = DateTime.Now;
            
            await WriteAllToFileAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var entities = await ReadAllFromFileAsync();
            var entity = entities.FirstOrDefault(e => e.Id == id);
            
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found");
            }
            
            entities.Remove(entity);
            await WriteAllToFileAsync(entities);
        }
    }
}
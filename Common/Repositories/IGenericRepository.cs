using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Repositories
{
    // Generic repository interface for CRUD operations
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetEntitiesAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetEntityByIdAsync<TEntity>(object id) where TEntity : class;
        Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteEntityAsync<TEntity>(object id) where TEntity : class;
        Task<bool> SaveChangesAsync();
    }
}

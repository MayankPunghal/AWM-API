namespace usermanagement_api.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
    }

}

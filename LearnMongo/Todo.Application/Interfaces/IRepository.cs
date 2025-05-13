namespace Todo.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>?> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(string Id, CancellationToken cancellationToken);
        Task AddAsync(T enitity, CancellationToken cancellationToken);
        Task UpdateAsync(T enitity, CancellationToken cancellationToken);
        Task DeleteAsync(string Id, CancellationToken cancellationToken);
    }
}

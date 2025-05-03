using Todo.Core.Entities;

namespace Todo.Application.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>?> GetAllAsync(CancellationToken cancellationToken);
        Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(TodoItem item, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

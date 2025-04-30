using Todo.Core.Entities;

namespace Todo.Application.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>?> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task AddAsync(TodoItem item);
        Task DeleteAsync(int id);
    }
}

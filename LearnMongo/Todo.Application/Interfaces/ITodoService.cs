using Todo.Application.DTOs;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>?> GetAllTodosAsync();
        Task<TodoItemDto?> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(TodoItemDto item);
        Task DeleteTodoAsync(int id);
    }
}

using Todo.Application.DTOs;

namespace Todo.Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>?> GetAllTodosAsync();
        Task<TodoItemDto?> GetTodoByIdAsync(string id);
        Task CreateTodoAsync(TodoItemDto item);
        Task DeleteTodoAsync(string id);
    }
}

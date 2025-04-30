using Todo.Application.Interfaces;
using Todo.Application.DTOs;
using Todo.Core.Entities;

namespace Todo.Infrastructure.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _todos = new List<TodoItem>();

        public Task AddAsync(TodoItem item)
        {
            _todos.Add(item);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            TodoItem? item = _todos.Find(x => x.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TodoItem>?> GetAllAsync()
        {
            return await Task.FromResult(_todos);
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(todo);
        }
    }
}

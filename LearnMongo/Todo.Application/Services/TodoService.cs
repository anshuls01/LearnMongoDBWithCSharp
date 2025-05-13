using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Core.Entities;

namespace Todo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;
        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateTodoAsync(TodoItemDto item)
        {
            TodoItem todo = new TodoItem
            {
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedAt = DateTime.Now,
            };

            await _repository.AddAsync(todo,new CancellationToken());
        }

        public async Task DeleteTodoAsync(string id)
        {
            await _repository.DeleteAsync(id, new CancellationToken());
        }

        public async Task<IEnumerable<TodoItemDto>?> GetAllTodosAsync()
        {
            var todos = await _repository.GetAllAsync(new CancellationToken());
            if (todos == null)
            {
                return null;
            }

            var todoItems = todos.Select(item => new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            });
            return todoItems;
        }

        public async Task<TodoItemDto?> GetTodoByIdAsync(string id)
        {
            var todoItem = await _repository.GetByIdAsync(id, new CancellationToken());
            if (todoItem == null)
            {
                return null;
            }
            var dto = new TodoItemDto
            {
                Id = todoItem.Id,
                IsCompleted = todoItem.IsCompleted,
                Title = todoItem.Title,
            };
            return dto;
        }
    }
}

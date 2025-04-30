using Microsoft.EntityFrameworkCore;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Core.Entities;
using Todo.Infrastructure.Context;

namespace Todo.Infrastructure.Repositories
{
    public class EfCoreTodoRepository : ITodoRepository
    {
        private readonly AppDbContext _dbContext;
        public EfCoreTodoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TodoItem item)
        {
            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>?> GetAllAsync()
        {
            var todos = await _dbContext.TodoItems.ToListAsync();
            return todos;
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            var todoItem = await _dbContext.TodoItems.FindAsync(id);
            return todoItem;
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _dbContext.TodoItems.FindAsync(id);
            if (item != null)
            {
                _dbContext.TodoItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

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
        public EfCoreTodoRepository(AppDbContext dbContext, CancellationToken cancellationToken)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(TodoItem item, CancellationToken cancellationToken)
        {
            _dbContext.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>?> GetAllAsync(CancellationToken cancellationToken)
        {
            var todos = await _dbContext.TodoItems.ToListAsync();
            return todos;
        }

        public async Task<TodoItem?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var todoItem = await _dbContext.TodoItems.FindAsync(id);
            return todoItem;
        }
        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var item = await _dbContext.TodoItems.FindAsync(id);
            if (item != null)
            {
                _dbContext.TodoItems.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task UpdateAsync(TodoItem enitity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

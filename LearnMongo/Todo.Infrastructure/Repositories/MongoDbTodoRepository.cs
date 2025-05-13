using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Todo.Application.Interfaces;
using Todo.Core.Entities;

namespace Todo.Infrastructure.Repositories
{
    public class MongoDbTodoRepository : ITodoRepository
    {
        private readonly IMongoCollection<TodoItem> _collection;
        public MongoDbTodoRepository(IMongoClient client, IConfiguration config)
        {
            var database = client.GetDatabase("TodoDb");
            _collection = database.GetCollection<TodoItem>("TodoItems");
        }
        public async Task AddAsync(TodoItem item, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(item, null, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(x => x.Id == id, null, cancellationToken);
        }

        public async Task<IEnumerable<TodoItem>?> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = await _collection.Find(_ => true).ToListAsync(cancellationToken);

            return items.Select(x => new TodoItem
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    IsCompleted = x.IsCompleted
                                }).ToList();
        }

        public async Task<TodoItem?> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
           return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync(cancellationToken); 
        }

        public Task UpdateAsync(TodoItem enitity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

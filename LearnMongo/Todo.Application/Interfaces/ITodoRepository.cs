using Todo.Core.Entities;

namespace Todo.Application.Interfaces
{
    public interface ITodoRepository:IRepository<TodoItem>
    {
        // more methods to implement specific to todo
    }
}

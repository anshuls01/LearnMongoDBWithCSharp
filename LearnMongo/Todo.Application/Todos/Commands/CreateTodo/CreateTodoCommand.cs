using MediatR;
using Todo.Application.DTOs;

namespace Todo.Application.Todos.Commands.CreateTodo
{
    public record CreateTodoCommand(TodoItemDto todoDto) : IRequest<Unit>;

}

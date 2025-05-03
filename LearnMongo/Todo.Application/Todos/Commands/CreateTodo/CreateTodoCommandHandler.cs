using MediatR;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

namespace Todo.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Unit>
    {
        private readonly ITodoService _todoService;
        public CreateTodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<Unit> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            TodoItemDto todo = request.todoDto;
            await _todoService.CreateTodoAsync(todo);
            return Unit.Value;
        }

    }
}

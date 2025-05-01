using FluentValidation;
using Todo.Application.DTOs;

namespace Todo.Application.Validators
{
    public class TodoItemDtoValidator : AbstractValidator<TodoItemDto>
    {
        public TodoItemDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title is required")
                .MaximumLength(100);
        }
    }
}

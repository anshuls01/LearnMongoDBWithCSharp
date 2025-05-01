using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.DTOs;

namespace Todo.Application.Validators
{
    public class TodoItemDtoValidator : AbstractValidator<TodoItemDto>
    {
        public TodoItemDtoValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Max Allowed length is 100");
        }
    }
}

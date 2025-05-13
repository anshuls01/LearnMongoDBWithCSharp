using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Application.Todos.Commands.CreateTodo;

namespace Todo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;
        private readonly IMediator mediator;   
        public TodoController(ITodoService _todoService, IMediator _mediator)
        {
            todoService = _todoService;
            mediator = _mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(string id)
        {
            var todoItem = await todoService.GetTodoByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> Get()
        {
            var todos = await todoService.GetAllTodosAsync();
            if (todos == null)
            {
                return NotFound();
            }

            return Ok(todos);
        }

        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] TodoItemDto todo)
        //{
        //    if (todo == null)
        //    {
        //        return BadRequest();
        //    }

        //    await todoService.CreateTodoAsync(todo);

        //    return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        //}


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoItemDto todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            await mediator.Send(new CreateTodoCommand(todo));
            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(string id)
        {
            await todoService.DeleteTodoAsync(id);
            return Ok();
        }
    }
}

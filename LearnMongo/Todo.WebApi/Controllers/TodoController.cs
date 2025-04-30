using Microsoft.AspNetCore.Mvc;
using Todo.Application.Interfaces;
using Todo.Application.DTOs;

namespace Todo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(int id)
        {
            var todoItem = await _todoService.GetTodoByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> Get()
        {
            var todos = await _todoService.GetAllTodosAsync();
            if (todos == null)
            {
                return NotFound();
            }

            return Ok(todos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoItemDto todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            await _todoService.CreateTodoAsync(todo);

            return CreatedAtAction(nameof(Get), new { id = todo.Id }, todo);
        }

    }
}

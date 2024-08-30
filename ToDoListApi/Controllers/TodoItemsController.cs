using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Data.Repository;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemsController(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var items = await _repository.GetTodoItems();
            return Ok(items);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(int id)
        {
            var todoItem = await _repository.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<IActionResult> PostTodoItem(TodoItem todoItem)
        {
            await _repository.AddTodoItem(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            await _repository.UpdateTodoItem(todoItem);
            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _repository.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            await _repository.DeleteTodoItem(id);
            return NoContent();
        }
    }
}

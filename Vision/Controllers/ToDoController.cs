using Microsoft.AspNetCore.Mvc;
using Vision.Model;

namespace Vision.Controllers
{
    // TodosController.cs
    [ApiController]
    [Route("api/boards/{boardId}/todos")]
    public class TodosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/boards/{boardId}/todos
        // GET api/boards/{boardId}/todos
        [HttpGet]
        public IActionResult GetTodos(int boardId)
        {
            var todos = _context.ToDos.Where(t => t.BoardId == boardId).ToList();
            return Ok(todos);
        }

        // GET api/boards/{boardId}/todos?done=false
        [HttpGet("uncompletedtodos")]
        public IActionResult GetUncompletedTodos(int boardId)
        {
            var todos = _context.ToDos.Where(t => t.BoardId == boardId && !t.Done).ToList();
            return Ok(todos);
        }


        // POST api/boards/{boardId}/todos
        [HttpPost]
        public IActionResult CreateTodoItem(int boardId, ToDo todo)
        {
            var board = _context.Boards.Find(boardId);
            if (board == null)
                return NotFound();

            todo.Board = board;
            _context.ToDos.Add(todo);
            _context.SaveChanges();

            return Ok(todo);
        }

        // PUT api/todos/{todoId}
        [HttpPut("{todoId}")]
        public IActionResult UpdateTodoItem(int todoId, ToDo updatedTodo)
        {
            var todo = _context.ToDos.Find(todoId);
            if (todo == null)
                return NotFound();

            todo.Title = updatedTodo.Title;
            todo.Done = updatedTodo.Done;
            todo.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();

            return Ok(todo);
        }

        // DELETE api/todos/{todoId}
        [HttpDelete("{todoId}")]
        public IActionResult DeleteTodoItem(int todoId)
        {
            var todo = _context.ToDos.Find(todoId);
            if (todo == null)
                return NotFound();

            _context.ToDos.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

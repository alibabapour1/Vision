using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vision.Model;

namespace Vision.Controllers
{
    [ApiController]
    [Route("api/boards")]
    public class BoardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/boards
        [HttpGet]
        public IActionResult GetAllBoards()
        {
            var boards = _context.Boards.Include(b => b.ToDos).ToList();
            return Ok(boards);
        }

        // POST api/boards
        [HttpPost]
        public IActionResult CreateBoard(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
            return Ok(board);
        }

        // PUT api/boards/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBoard(int id, Board updatedBoard)
        {
            var board = _context.Boards.Find(id);
            if (board == null)
                return NotFound();

            board.Name = updatedBoard.Name;
            _context.SaveChanges();

            return Ok(board);
        }

        // DELETE api/boards/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            var board = _context.Boards.Find(id);
            if (board == null)
                return NotFound();

            _context.Boards.Remove(board);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("todos")]
    public class TodoController(TodoAppContext context) : Controller
    {

        private readonly TodoAppContext _context = context;

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.OrderBy(todo => todo.IsCompleted).ThenByDescending(todo => todo.Id).ToListAsync();
            return View(todos);
        }
        [HttpGet("api")]
        public async Task<IActionResult> IndexApi()
        {
            var todos = await _context.Todos.OrderBy(todo => todo.IsCompleted).ThenByDescending(todo => todo.Id).ToListAsync();

            return Ok(todos);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var todo = await _context.Todos.FirstAsync(todo => todo.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(Todo todo)

        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
        [HttpGet("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            return View(todo);
        }
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,IsCompleted")] Todo todo)

        {
            if (id != todo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
        
        [HttpGet("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id, [Bind("Id,Title,Description,DueDate,IsCompleted")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            var todoToDelete = await _context.Todos.FindAsync(todo.Id);
            if (todoToDelete != null)
            {
                _context.Todos.Remove(todoToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
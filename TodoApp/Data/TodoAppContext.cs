using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoAppContext(DbContextOptions<TodoAppContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}

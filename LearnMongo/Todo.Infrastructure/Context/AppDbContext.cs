using Microsoft.EntityFrameworkCore;
using Todo.Core.Entities;

namespace Todo.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
        public TodoContext() { }


        public virtual DbSet<TodoItem> TodoItems { get; set; }
    }
}

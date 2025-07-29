using Microsoft.EntityFrameworkCore;
using proje.Entities;

namespace proje.Data
{
    public class ToDodbContext : DbContext
    {
        public ToDodbContext(DbContextOptions<ToDodbContext>options) : base(options) {}
        
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}

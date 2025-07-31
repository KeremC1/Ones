using Microsoft.EntityFrameworkCore;
using proje.Application.Interfaces;
using proje.Data;
using proje.Entities;

namespace proje.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDodbContext _context;

        public ToDoRepository(ToDodbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(Guid id)
        {
            return await _context.ToDos.FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<ToDoItem> AddAsync(ToDoItem item)
        {
            _context.ToDos.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _context.ToDos.FindAsync(id);
            if (item == null) return false;

            _context.ToDos.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem item)
        {
            var existing = await _context.ToDos.FirstOrDefaultAsync(t => t.ID == item.ID);
            if (existing == null) return null;

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}

using proje.Entities;

namespace proje.Application.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(Guid id);
        Task<ToDoItem> AddAsync(ToDoItem item);
        Task<bool> DeleteAsync(Guid id);
        Task<ToDoItem> UpdateAsync(ToDoItem item);
    }
}

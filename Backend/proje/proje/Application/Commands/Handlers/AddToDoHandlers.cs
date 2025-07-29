using MediatR;
using proje.Application.Commands;
using proje.Data;
using proje.Entities;
namespace proje.Application.Commands.Handlers
{
    public class AddToDoHandler : IRequestHandler<AddToDoCommand, ToDoItem>
    {
        private readonly ToDodbContext _context;

        public AddToDoHandler(ToDodbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> Handle(AddToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDoItem
            {
                ID = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                CreatedAt = DateTime.UtcNow
            };

            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }
    }
}

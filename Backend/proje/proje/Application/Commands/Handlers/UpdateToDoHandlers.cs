using MediatR;
using proje.Application.Commands;
using proje.Data;
using proje.Entities;
using Microsoft.EntityFrameworkCore;

namespace proje.Application.Commands.Handlers
{
    public class UpdateToDoHandler : IRequestHandler<UpdateToDoCommand, ToDoItem>
    {
        private readonly ToDodbContext _context;

        public UpdateToDoHandler(ToDodbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(t => t.ID == request.ID, cancellationToken);

            if (todo == null)
                return null;

            
            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.IsCompleted = request.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);

            return todo;
        }
    }
}

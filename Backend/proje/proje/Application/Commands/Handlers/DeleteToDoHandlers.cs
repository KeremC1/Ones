using MediatR;
using proje.Application.Commands;
using proje.Data;

namespace proje.Application.Commands.Handlers
{
    public class DeleteToDoHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly ToDodbContext _context;

        public DeleteToDoHandler(ToDodbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _context.ToDos.FindAsync(request.ID);
            if (todo == null)
                return false;

            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

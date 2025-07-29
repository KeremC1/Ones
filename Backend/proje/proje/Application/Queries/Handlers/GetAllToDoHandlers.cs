using MediatR;
using Microsoft.EntityFrameworkCore;
using proje.Data;
using proje.Entities;

namespace proje.Application.Queries.Handlers
{
    public class GetAllToDosHandler : IRequestHandler<GetAllToDosQuery, List<ToDoItem>>
    {
        private readonly ToDodbContext _context;

        public GetAllToDosHandler(ToDodbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDoItem>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
        {
            return await _context.ToDos.ToListAsync();
        }
    }
}

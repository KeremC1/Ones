using MediatR;
using proje.Application.Interfaces;
using proje.Entities;

namespace proje.Application.Queries.Handlers
{
    public class GetAllToDosHandler : IRequestHandler<GetAllToDosQuery, List<ToDoItem>>
    {
        private readonly IToDoRepository _repository;

        public GetAllToDosHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ToDoItem>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

using MediatR;
using proje.Application.Commands;
using proje.Application.Interfaces;
using proje.Entities;

namespace proje.Application.Commands.Handlers
{
    public class AddToDoHandler : IRequestHandler<AddToDoCommand, ToDoItem>
    {
        private readonly IToDoRepository _repository;

        public AddToDoHandler(IToDoRepository repository)
        {
            _repository = repository;
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

            return await _repository.AddAsync(todo);
        }
    }
}

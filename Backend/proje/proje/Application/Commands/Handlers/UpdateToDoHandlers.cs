using MediatR;
using proje.Application.Commands;
using proje.Application.Interfaces;
using proje.Entities;

namespace proje.Application.Commands.Handlers
{
    public class UpdateToDoHandler : IRequestHandler<UpdateToDoCommand, ToDoItem>
    {
        private readonly IToDoRepository _repository;

        public UpdateToDoHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItem> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDoItem
            {
                ID = request.ID,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted
            };

            return await _repository.UpdateAsync(todo);
        }
    }
}

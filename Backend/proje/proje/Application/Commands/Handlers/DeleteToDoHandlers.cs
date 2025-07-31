using MediatR;
using proje.Application.Commands;
using proje.Application.Interfaces;

namespace proje.Application.Commands.Handlers
{
    public class DeleteToDoHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly IToDoRepository _repository;

        public DeleteToDoHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.ID);
        }
    }
}

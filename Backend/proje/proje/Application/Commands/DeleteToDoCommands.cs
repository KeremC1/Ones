using MediatR;

namespace proje.Application.Commands
{
    public class DeleteToDoCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
    }
}

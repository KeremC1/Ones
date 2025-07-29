using MediatR;
using proje.Entities;


namespace proje.Application.Commands
{
    public class AddToDoCommand : IRequest<ToDoItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

    }
}

using MediatR;
using proje.Entities;


namespace proje.Application.Queries
{
    public class GetAllToDosQuery : IRequest<List<ToDoItem>> { }
}

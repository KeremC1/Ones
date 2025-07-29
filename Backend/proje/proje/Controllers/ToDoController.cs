using MediatR;
using Microsoft.AspNetCore.Mvc;
using proje.Application.Commands;
using proje.Application.Queries;


namespace proje.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDos()
        {
            var todos = await _mediator.Send(new GetAllToDosQuery());
            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> AddToDo([FromBody] AddToDoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> UpdateToDo(Guid ID, [FromBody] UpdateToDoCommand command)
        {
            command.ID = ID;
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteToDo(Guid ID)
        {
            var result = await _mediator.Send(new DeleteToDoCommand { ID = ID });
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}

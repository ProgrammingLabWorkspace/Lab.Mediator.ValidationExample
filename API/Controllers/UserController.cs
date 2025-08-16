using Lab.Mediator.ValidationExample.Application.Commands.UsersCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Mediator.ValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);

            return Created();
        }
    }
}

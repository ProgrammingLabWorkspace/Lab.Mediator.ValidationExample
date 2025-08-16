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
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Recebe a requisição para criar um usuário.
        /// </summary>
        /// <param name="userCommand"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand userCommand)
        {
            _logger.LogInformation("Processando requisição para criar um usuário");
            _logger.LogInformation("Enviando comando para o Mediator");

            await _mediator.Send(userCommand);

            _logger.LogInformation("Retornando 201 - Usuário criado com sucesso");
            return Created();
        }
    }
}

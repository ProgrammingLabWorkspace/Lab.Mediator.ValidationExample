using Lab.Mediator.ValidationExample.Application.Map;
using MediatR;

namespace Lab.Mediator.ValidationExample.Application.Commands.UsersCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        /// <summary>
        /// Processa o cadastro de um usuário
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Id = Guid.NewGuid().ToString();
            var user = request.ToUser();

            // Para simplificar, retorna apenas o id.
            return Task.FromResult(user.Id);
        }
    }
}

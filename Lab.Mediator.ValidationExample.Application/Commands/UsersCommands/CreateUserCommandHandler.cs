using MediatR;

namespace Lab.Mediator.ValidationExample.Application.Commands.UsersCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

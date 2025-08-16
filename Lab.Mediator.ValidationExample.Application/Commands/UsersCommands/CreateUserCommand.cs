using MediatR;

namespace Lab.Mediator.ValidationExample.Application.Commands.UsersCommands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}

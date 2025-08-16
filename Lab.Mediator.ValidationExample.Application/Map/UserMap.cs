using Lab.Mediator.ValidationExample.Application.Commands.UsersCommands;
using Lab.Mediator.ValidationExample.Core.Entities;

namespace Lab.Mediator.ValidationExample.Application.Map
{
    public static class UserMap
    {
        public static User ToUser(this CreateUserCommand createUserCommand)
        {
            return new User
            {
                Id = createUserCommand.Id,
                Name = createUserCommand.Name,
                Phone = createUserCommand.Phone
            };
        }
    }
}

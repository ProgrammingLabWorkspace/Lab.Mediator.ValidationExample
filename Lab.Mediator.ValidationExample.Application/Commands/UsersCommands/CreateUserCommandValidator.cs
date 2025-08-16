using FluentValidation;

namespace Lab.Mediator.ValidationExample.Application.Commands.UsersCommands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        /// <summary>
        /// Valida se os atributos de CreateUserCommand estão válidos.
        /// </summary>
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Nome é obrigatório");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Telefone é obrigatório");

            RuleFor(x => x.Phone)
                .NotNull()
                .WithMessage("Telefone é obrigatório");
        }
    }
}

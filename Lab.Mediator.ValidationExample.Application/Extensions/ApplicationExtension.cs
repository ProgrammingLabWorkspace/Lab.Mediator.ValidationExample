using FluentValidation;
using Lab.Mediator.ValidationExample.Application.Commands.UsersCommands;
using Lab.Mediator.ValidationExample.Application.PipelineBehavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Lab.Mediator.ValidationExample.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(ApplicationException).Assembly;

            services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()
                    , appAssembly);
            });

            return services;
        }


    }
}

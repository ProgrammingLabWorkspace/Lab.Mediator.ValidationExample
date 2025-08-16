using FluentValidation;
using MediatR;

namespace Lab.Mediator.ValidationExample.Application.PipelineBehavior
{
    using Lab.Mediator.ValidationExample.Core.Exceptions;
    using Microsoft.Extensions.Logging;

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var commandName = request.GetType().Name;

            _logger.LogInformation($"Validando comando: {commandName}");

            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(result => result != null)
                .ToList();

            // Se falhou na validação...
            if (failures.Any()) {
                // Trata os atributos inválido e devolve um resposta.
                _logger.LogInformation($"Falha na validação do comando {commandName}");
                var errors = new Dictionary<string, string>();

                failures.ForEach(failure => {
                    _logger.LogInformation($"{failure.PropertyName}: {failure.ErrorMessage}");

                    errors.TryAdd(failure.PropertyName, failure.ErrorMessage);
                });

                _logger.LogInformation($"Lançando exceção - ValidationException");
                throw new ValidationException(errors);
            }

            _logger.LogInformation($"Validação realizada e não foi localizado erros.");
            _logger.LogInformation($"Processando comando - {commandName}");

            var result = await next();
            // Post 
            _logger.LogInformation($"Comando realizado com sucesso - {nameof(request)}");
            return result;
        }
    }
}

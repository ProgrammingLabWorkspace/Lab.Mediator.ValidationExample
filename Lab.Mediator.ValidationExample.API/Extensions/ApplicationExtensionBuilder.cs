using Lab.Mediator.ValidationExample.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Lab.Mediator.ValidationExample.Extensions
{
    public static class ApplicationExtensionBuilder
    {
        /// <summary>
        /// Tratamento global para erros.
        /// </summary>
        /// <param name="app"></param>
        public static void UseValidationExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if(exception is not ValidationException)
                    {
                        context.Response.StatusCode = 500;

                        await context.Response.WriteAsync("Um erro inesperado ocorreu.");
                    }

                    // Se falhou na verificação do comando...
                    // então prepara um retorno com status code 400 e especifica quais campos estão incorretos.
                    var validationException = exception as ValidationException;

                    var errors = validationException.GetErrors();

                    var jErrors = JsonSerializer.Serialize(errors);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsync(jErrors);
                });
            });
        }
    }
}

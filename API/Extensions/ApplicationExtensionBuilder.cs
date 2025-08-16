using Lab.Mediator.ValidationExample.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Lab.Mediator.ValidationExample.Extensions
{
    public static class ApplicationExtensionBuilder
    {
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
                        throw exception;
                    }

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

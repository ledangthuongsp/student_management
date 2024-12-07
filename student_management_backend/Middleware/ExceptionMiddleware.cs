using student_management_backend.Common.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace student_management_backend.Middleware;

public class ExceptionMiddleware : IMiddleware
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
    };

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var errorResult = new ErrorResult
            {
                Source = exception.TargetSite?.DeclaringType?.FullName,
                Messages = [exception.Message]
            };

            if (exception is not CustomException && exception.InnerException != null)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
            }

            switch (exception)
            {
                case CustomException e:
                    context.Response.StatusCode = errorResult.StatusCode = (int)e.StatusCode;
                    if (e.ErrorMessages is not null)
                    {
                        errorResult.Messages = e.ErrorMessages;
                    }

                    break;

                case KeyNotFoundException:
                    context.Response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                default:
                    context.Response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResult, _options));
        }
    }
}

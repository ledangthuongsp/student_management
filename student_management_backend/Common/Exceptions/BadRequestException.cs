using System.Net;

namespace student_management_backend.Common.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message)
        : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}
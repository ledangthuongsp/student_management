using System.Net;

namespace student_management_backend.Common.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message)
       : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}
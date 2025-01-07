using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Exceptions;
using student_management_backend.Core.Models;
using System.Security.Claims;

namespace student_management_backend.Middleware;

public class ParseClaimsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
    {
        // Check if the user is authenticated
        if (context.User.Identity != null && context.User.Identity.IsAuthenticated)
        {
            var dbContext = context.RequestServices.GetRequiredService<NeonDbContext>();

            string userIdentifier = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new InternalServerException("Can not get current user id.");
            if (!Int32.TryParse(userIdentifier, out int userId))
            {
                throw new InternalServerException("Can not parse current user id.");
            }

            context.Items["User"] = await dbContext.User.FirstOrDefaultAsync(x => x.Id == userId);
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Exceptions;
using student_management_backend.DTOs.Response;
using student_management_backend.Models;
using System.Diagnostics;

namespace student_management_backend.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly NeonDbContext _context;

    public UserController(NeonDbContext context)
    {
        _context = context;
    }

    [HttpPut("{userId:int}")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId);
        if (user == null)
        {
            throw new NotFoundException("User doesn't exist");
        }

        user.FullName = request.FullName;
        user.PhoneNumber = request.PhoneNumber;
        user.DateOfBirth = request.DateOfBirth;

        await _context.SaveChangesAsync();

        return Ok(new { Message = "User updated successfully" });
    }
}

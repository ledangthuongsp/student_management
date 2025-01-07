using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using student_management_backend.DTOs.Request;
using student_management_backend.Common.Exceptions;
using student_management_backend.Core.Models;
using student_management_backend.DTOs.Response;
using Microsoft.AspNetCore.Authorization;

namespace student_management_backend.Controllers;

[Authorize]
[Route("api/submit")]
[ApiController]
public class SubmitController : ControllerBase
{
    private readonly NeonDbContext _context;

    public SubmitController(NeonDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = nameof(EUserRole.Student))]
    [HttpPost("")]
    public async Task<IActionResult> CreateSubmitForAssignment([FromBody] CreatSubmitRequest body)
    {
        var assignment = await _context.Assignment.FirstOrDefaultAsync(x => x.Id == body.AssignmentId) ?? throw new NotFoundException("Assignment doesn't exist.");
        var user = HttpContext.Items["User"] as User;

        var submit = new Submit()
        {
            AssignmentId = body.AssignmentId,
            Description = body.Description,
            StudentId = user.Id,
            AttachFile = body.FileUrl
        };

        await _context.Submit.AddAsync(submit);
        await _context.SaveChangesAsync();

        return Ok(submit.Id);
    }

    [Authorize(Roles = nameof(EUserRole.Student))]
    [HttpDelete("{submitId:int}")]
    public async Task<IActionResult> DeleteSubmit(int submitId)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == submitId) ?? throw new NotFoundException("Submit doesn't exist.");
        var user = HttpContext.Items["User"] as User;
        if (submit.StudentId != user.Id)
        {
            throw new ForbiddenException("You are not the owner of this submit.");
        }

        submit.DeletedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [Authorize(Roles = nameof(EUserRole.Student))]
    [HttpPut("{submitId:int}")]
    public async Task<IActionResult> UpdateSubmit(int submitId, [FromBody] UpdateSubmitRequest body)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == submitId) ?? throw new NotFoundException("Submit doesn't exist.");
        var user = HttpContext.Items["User"] as User;
        if (submit.StudentId != user.Id)
        {
            throw new ForbiddenException("You are not the owner of this submit.");
        }

        var entry = _context.Entry(submit);
        foreach (var property in entry.Properties)
        {
            var bodyProperty = body.GetType().GetProperty(property.Metadata.Name);
            if (bodyProperty != null) 
            {
                var newValue = bodyProperty.GetValue(body); 
                if (newValue != null) 
                {
                    property.CurrentValue = newValue; 
                    property.IsModified = true;
                }
            }
        }

        await _context.SaveChangesAsync();

        return Ok(submit.Id);
    }

    [HttpGet("{submitId:int}")]
    public async Task<SubmitResponse> GetSubmitDetail(int submitId)
    {
        var submit = await _context.Submit
            .Where(x => x.Id == submitId)
            .Include(x => x.Student)
            .Select(x => new SubmitResponse()
            {
                Id = x.Id,
                Description = x.Description,
                AttachFile = x.AttachFile,
                Owner = new UserResponse()
                {
                    Id = x.Student.Id,
                    Email = x.Student.Email ?? "",
                    FullName = x.Student.FullName ?? "",
                    AvatarUrl = x.Student.AvatarUrl,
                }
            })
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Submit doesn't exist.");

        return submit;
    }

    [HttpGet("students/{studentId:int}")]
    public async Task<ICollection<SubmitResponse>> GetListSubmitsByStudentId(int studentId)
    {
        var submits = await _context.Submit
            .Where(x => x.StudentId == studentId)
            .Include(x => x.Student)
            .Select(x => new SubmitResponse()
            {
                Id = x.Id,
                Description = x.Description,
                AttachFile = x.AttachFile,
                Owner = new UserResponse()
                {
                    Id = x.Student.Id,
                    Email = x.Student.Email ?? "",
                    FullName = x.Student.FullName ?? "",
                    AvatarUrl = x.Student.AvatarUrl,
                }
            })
            .ToListAsync();

        return submits;
    }

    [HttpGet("assignments/{assignmentId:int}")]
    public async Task<ICollection<SubmitResponse>> GetListSubmitsByAssignmentId(int assignmentId)
    {
        var submits = await _context.Submit
            .Where(x => x.AssignmentId == assignmentId)
            .Include(x => x.Student)
            .Select(x => new SubmitResponse()
            {
                Id = x.Id,
                Description = x.Description,
                AttachFile = x.AttachFile,
                Owner = new UserResponse()
                {
                    Id = x.Student.Id,
                    Email = x.Student.Email ?? "",
                    FullName = x.Student.FullName ?? "",
                    AvatarUrl = x.Student.AvatarUrl,
                }
            })
            .ToListAsync();

        return submits;
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using student_management_backend.DTOs.Request;
using student_management_backend.Common.Exceptions;
using student_management_backend.Models;
using student_management_backend.DTOs.Response;

namespace student_management_backend.Controllers;

[Route("api/submit")]
[ApiController]
public class SubmitController : ControllerBase
{
    private readonly NeonDbContext _context;

    public SubmitController(NeonDbContext context)
    {
        _context = context;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSubmitForAssignment([FromBody] CreatSubmitRequest body)
    {
        var assignment = await _context.Assignment.FirstOrDefaultAsync(x => x.Id == body.AssignmentId) ?? throw new NotFoundException("Assignment doesn't exist.");

        var submit = new Submit()
        {
            AssignmentId = body.AssignmentId,
            Description = body.Description,
            StudentId = body.StudentId,
            AttachFile = body.FileUrl
        };

        await _context.Submit.AddAsync(submit);
        await _context.SaveChangesAsync();

        return Ok(submit.Id);
    }

    [HttpDelete("{submitId:int}")]
    public async Task<IActionResult> DeleteSubmit(int submitId)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == submitId) ?? throw new NotFoundException("Submit doesn't exist");

        submit.DeletedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{submitId:int}")]
    public async Task<IActionResult> UpdateSubmit(int submitId, [FromBody] UpdateSubmitRequest body)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == submitId) ?? throw new NotFoundException("Submit doesn't exist");

        var entry = _context.Entry(submit);
        foreach (var property in entry.Properties)
        {
            // Get the matching property from the body object
            var bodyProperty = body.GetType().GetProperty(property.Metadata.Name);
            if (bodyProperty != null) // Ensure the property exists in the body
            {
                var newValue = bodyProperty.GetValue(body); // Get the value from the body
                if (newValue != null) // Only update non-null values
                {
                    property.CurrentValue = newValue; // Update the property
                    property.IsModified = true;      // Mark as modified
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
                    Email = x.Student.Email,
                    FullName = x.Student.FullName,
                    AvatarUrl = x.Student.AvatarUrl,
                }
            })
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Submit doesn't exist");

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
                    Email = x.Student.Email,
                    FullName = x.Student.FullName,
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
                    Email = x.Student.Email,
                    FullName = x.Student.FullName,
                    AvatarUrl = x.Student.AvatarUrl,
                }
            })
            .ToListAsync();

        return submits;
    }
}

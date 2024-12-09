using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using student_management_backend.DTOs.Response;
using student_management_backend.Common.Exceptions;
using student_management_backend.Models;
using student_management_backend.DTOs.Request;

namespace student_management_backend.Controllers;

[Route("api/assignment")]
[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly NeonDbContext _context;

    public AssignmentController(NeonDbContext context)
    {
        _context = context;
    }

    [HttpGet("{assignmentId:int}")]
    public async Task<AssignmentDetailResponse> GetAssignmentDetail(int assignmentId)
    {
        var assignment = await _context.Assignment
            .Where(x => x.Id == assignmentId)
            .Include(x => x.Subject)
            .ThenInclude(x => x.Assignments)
            .ThenInclude(x => x.User)
            .Select(x => new AssignmentDetailResponse()
            {
                Id = assignmentId,
                Title = x.Title,
                Grade = x.Grade,
                Semester = x.Semester,
                Type = ((EAssignmentType)x.Type).ToString(),
                Description = x.Description,
                DueDate = x.DueDate,
                Classroom = new AssignmentDetailClassResponse()
                {
                    ClassName = x.Class.ClassName,
                },
                Subject = new AssignmentDetailSubjectResponse()
                {
                    Title = x.Subject.Title,
                },
                Teacher = new AssignmentDetailTeacherResponse()
                {
                    FullName = x.User.FullName
                }
            }).FirstOrDefaultAsync() ?? throw new NotFoundException("Assignment doesn't exist");

        return assignment;
    }

    [HttpGet("list")]
    public async Task<List<AssignmentDetailResponse>> GetListAssignments()
    {
        var assignment = await _context.Assignment
           .Include(x => x.Subject)
           .ThenInclude(x => x.Assignments)
           .ThenInclude(x => x.User)
           .Select(x => new AssignmentDetailResponse()
           {
               Id = x.Id,
               Title = x.Title,
               Grade = x.Grade,
               Semester = x.Semester,
               Type = ((EAssignmentType)x.Type).ToString(),
               Description = x.Description,
               DueDate = x.DueDate,
               Classroom = new AssignmentDetailClassResponse()
               {
                   ClassName = x.Class.ClassName,
               },
               Subject = new AssignmentDetailSubjectResponse()
               {
                   Title = x.Subject.Title,
               },
               Teacher = new AssignmentDetailTeacherResponse()
               {
                   FullName = x.User.FullName
               }
           }).ToListAsync() ?? throw new NotFoundException("Assignment doesn't exist");

        return assignment;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentRequest body)
    {
        bool isParsingSuccedded = Enum.TryParse(body.Type, out EAssignmentType type);

        if (!isParsingSuccedded)
        {
            throw new BadRequestException("Type is not allowed");
        }

        var assignment = new Assignment()
        {
            Title = body.Title,
            Grade = body.Grade,
            Semester = body.Semester,
            Type = type,
            Description = body.Description ?? "",
            DueDate = body.DueDate,
            SubjectId = body.SubjectId,
            TeacherId = body.TeacherId,
            ClassId = body.ClassId
        };

        await _context.Assignment.AddAsync(assignment);
        await _context.SaveChangesAsync();

        return Ok(assignment.Id);
    }

    [HttpPut("{assignmentId:int}")]
    public async Task<IActionResult> UpdateAssignment(int assignmentId, [FromBody] UpdateAssignmentRequest body)
    {
        var assignment = await _context.Assignment.FirstOrDefaultAsync(x => x.Id == assignmentId) ?? throw new NotFoundException("Assignment doesn't exist");

        var entry = _context.Entry(assignment);
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

        return Ok(assignment.Id);
    }

    [HttpDelete("{assignmentId:int}")]
    public async Task<IActionResult> DeleteAssignment(int assignmentId)
    {
        var assignment = await _context.Assignment.FirstOrDefaultAsync(x => x.Id == assignmentId) ?? throw new NotFoundException("Assignment doesn't exist");

        assignment.DeletedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok();
    }

}

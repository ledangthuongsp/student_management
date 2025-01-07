using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Exceptions;
using student_management_backend.DTOs.Response;
using student_management_backend.Core.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using student_management_backend.DTOs.Request;
using student_management_backend.Config.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace student_management_backend.Controllers;

[Authorize]
[Route("api/class")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly NeonDbContext _context;

    public ClassController(NeonDbContext context)
    {
        _context = context;
    }

    [HttpGet("{classId:int}")]
    public async Task<ClassDetailResponse> GetClassDetail(int classId)
    {
        var classroom = await _context.Class
            .Include(x => x.SchoolYear)
            .Where(x => x.Id == classId)
            .Select(x => new ClassDetailResponse()
            {
                Id = classId,
                ClassName = x.ClassName,
                Grade = x.Grade,
                SchoolYear = x.SchoolYear == null ? null : new SchoolYearResponse()
                {
                    SchoolYearId = x.SchoolYearId,
                    StartSchoolYear = x.SchoolYear.StartSchoolYear,
                    EndSchoolYear = x.SchoolYear.EndSchoolYear,
                }
            })
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Class doesn't exist.");

        return classroom;
    }

    [HttpGet("list")]
    public async Task<ICollection<ClassDetailResponse>> GetListClass([FromQuery] GetListClassRequest body)
    {
        if (body.StartSchoolYear != null && body.EndSchoolYear != null && body.StartSchoolYear > body.EndSchoolYear)
        {
            throw new BadRequestException("Start school year cannot be larger than end scholl year.");
        }

        var query = _context.Class
           .Include(x => x.SchoolYear)
           .AsQueryable();

        if (body.StartSchoolYear != null)
        {
            query = query.Where(x => x.SchoolYear.StartSchoolYear >= body.StartSchoolYear);
        }
        if (body.EndSchoolYear != null)
        {
            query = query.Where(x => x.SchoolYear.EndSchoolYear <= body.EndSchoolYear);
        }
        if (body.Grade != null)
        {
            query = query.Where(x => x.Grade == body.Grade);
        }

        var classroomList = await query
           .Select(x => new ClassDetailResponse()
           {
               Id = x.Id,
               ClassName = x.ClassName,
               Grade = x.Grade,
               SchoolYear = x.SchoolYear == null ? null : new SchoolYearResponse()
               {
                   SchoolYearId = x.SchoolYearId,
                   StartSchoolYear = x.SchoolYear.StartSchoolYear,
                   EndSchoolYear = x.SchoolYear.EndSchoolYear,
               }
           })
           .ToListAsync();

        return classroomList;
    }

    [Authorize(Roles = nameof(EUserRole.Council))]
    [HttpPost("")]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassRequest body)
    {
        var schoolYear = await _context.SchoolYear.FirstOrDefaultAsync(x => x.Id == body.SchoolYearId) ?? throw new NotFoundException("School year not found.");

        var classroom = new Class()
        {
            ClassName = body.ClassName,
            SchoolYearId = body.SchoolYearId,
            Grade = body.Grade,
        };

        await _context.Class.AddAsync(classroom);
        await _context.SaveChangesAsync();
        return Ok(classroom.Id);
    }

    [Authorize(Roles = nameof(EUserRole.Council))]
    [HttpPut("{classId:int}")]
    public async Task<IActionResult> UpdateClass(int classId, [FromBody] UpdateClassRequest body)
    {
        var classroom = await _context.Class.FirstOrDefaultAsync(x => x.Id == classId) ?? throw new NotFoundException("Classroom not found.");

        var entry = _context.Entry(classroom);
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
        return Ok(classroom.Id);
    }
}

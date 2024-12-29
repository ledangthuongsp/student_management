using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Exceptions;
using student_management_backend.DTOs.Response;
using student_management_backend.Core.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
                    StartSchoolYear = x.SchoolYear.StartSchoolYear,
                    EndSchoolYear = x.SchoolYear.EndSchoolYear,
                }
            })
            .FirstOrDefaultAsync() ?? throw new NotFoundException("Class doesn't exist");

        return classroom;
    }
}

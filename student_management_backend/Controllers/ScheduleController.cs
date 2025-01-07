using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Constants;
using student_management_backend.Common.Exceptions;
using student_management_backend.Core.Models;
using student_management_backend.DTOs.Request;
using student_management_backend.DTOs.Response;
using System;
using System.Collections.ObjectModel;

namespace student_management_backend.Controllers;

[Authorize]
[Route("api/schedule")]
[ApiController]
public class ScheduleController : ControllerBase
{
    private readonly NeonDbContext _context;

    public ScheduleController(NeonDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = nameof(EUserRole.Council))]
    [HttpPost("")]
    public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleRequest body)
    {
        if (body.EndApplyingDate.CompareTo(body.StartApplyingDate) < 0)
        {
            throw new BadRequestException("Start date cannot be later than end date.");
        }

        var distance = body.EndApplyingDate.Subtract(body.StartApplyingDate);

        if (distance.Days > 366)
        {
            throw new BadRequestException("Applying year is larger than 1 year.");
        }

        var classroom = await _context.Class
            .Include(x => x.SchoolYear)
            .FirstOrDefaultAsync(x => x.Id == body.ClassId) ?? throw new NotFoundException("Class not found.");

        if (classroom.Grade != body.Grade)
        {
            throw new BadRequestException("This class has passed or has not achieved this grade.");
        }

        if (!(classroom.SchoolYear.StartSchoolYear <= body.StartApplyingDate.Year && body.EndApplyingDate.Year <= classroom.SchoolYear.EndSchoolYear))
        {
            throw new BadRequestException("The given period doesnt not fit the school year of this class.");
        }

        var schedule = await _context.Schedule
            .Where(x => x.ClassId == body.ClassId && !(body.StartApplyingDate >= x.EndApplyingDate || body.EndApplyingDate <= x.StartApplyingDate))
            .ToListAsync();

        if (schedule.Count > 0)
        {
            throw new BadRequestException("There has already been a schedue in this period.");
        }

        var newSchedule = new Schedule()
        {
            ClassId = body.ClassId,
            Grade = body.Grade,
            StartApplyingDate = body.StartApplyingDate,
            EndApplyingDate = body.EndApplyingDate,
        };

        await _context.AddAsync(newSchedule);
        await _context.SaveChangesAsync();
        return Ok(newSchedule.Id);
    }

    [HttpGet("")]
    public async Task<ICollection<ScheduleDetailResponse>> GetScheduleByFilter([FromQuery] GetScheduleByClassId body)
    {

        var queryable = _context.Schedule
            .Include(x => x.ScheduleSubjects)
            .ThenInclude(sb => sb.Subject)
            .Include(x => x.Class)
            .ThenInclude(c => c.SchoolYear)
            .AsQueryable();

        if (body.ClassId != null)
        {
            queryable = queryable.Where(x => x.ClassId == body.ClassId);
        }

        if (body.StartSchoolYear != null)
        {
            queryable = queryable.Where(x => x.StartApplyingDate.Year == body.StartSchoolYear && (body.StartSchoolYear - x.Class.SchoolYear.StartSchoolYear + ConstantValues.InitialGrade) == x.Grade);
        }

        var schedule = await queryable
            .Select(x => new ScheduleDetailResponse()
            {
                ScheduleId = x.Id,
                EndApplyingDate = x.EndApplyingDate,
                StartApplyingDate = x.StartApplyingDate,
                Grade = x.Grade,
                SchoolYear = new SchoolYearResponse()
                {
                    SchoolYearId = x.Class.SchoolYearId,
                    StartSchoolYear = x.Class.SchoolYear.StartSchoolYear,
                    EndSchoolYear = x.Class.SchoolYear.EndSchoolYear,
                },
                Class = new ClassDetailResponse()
                {
                    Id = x.ClassId,
                    ClassName = x.Class.ClassName,
                },
                Subjects = x.ScheduleSubjects.Select(sb => new ScheduleSubjectResponse()
                {
                    SubjectId = sb.SubjectId,
                    Title = sb.Subject.Title,
                    DayOfWeek = (sb.DayOfWeek).ToString(),
                    StartPeriod = sb.StartPeriod,
                    EndPeriod = sb.EndPeriod,
                }).ToList()
            })
            .ToListAsync();

        return schedule;
    }

    [Authorize(Roles = nameof(EUserRole.Council))]
    [HttpPost("{scheduleId:int}/subjects")]
    public async Task<IActionResult> AddScheduleSubjects(int scheduleId, [FromBody] AddScheduleSubjectRequest body)
    {
        var schedule = await _context.Schedule.Where(x => x.Id == scheduleId).FirstOrDefaultAsync() ?? throw new NotFoundException("Schedule not found.");

        var scheduleSubjects = await _context.ScheduleSubject.Where(x => x.ScheduleId == scheduleId).ToListAsync();

        List<ScheduleSubject> scheduleSubjectList = [];

        foreach (var subject in body.Subjects)
        {
            if (subject.StartPeriod > subject.EndPeriod)
            {
                throw new BadRequestException("Start period can not be greater than end period.");
            }

            scheduleSubjectList.Find(item => item.DayOfWeek == subject.DayOfWeek && !(subject.EndPeriod < item.StartPeriod || subject.StartPeriod > item.EndPeriod));

            if (scheduleSubjectList.Count == 0)
            {
                var scheduleSubject = new ScheduleSubject()
                {
                    ScheduleId = scheduleId,
                    SubjectId = subject.SubjectId,
                    StartPeriod = subject.StartPeriod,
                    EndPeriod = subject.EndPeriod,
                    DayOfWeek = subject.DayOfWeek,
                };
                scheduleSubjectList.Add(scheduleSubject);
            }
        }

        await _context.AddRangeAsync(scheduleSubjectList);

        return Ok();
    }
}

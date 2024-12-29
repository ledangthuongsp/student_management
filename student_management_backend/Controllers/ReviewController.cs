using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student_management_backend.Common.Exceptions;
using student_management_backend.DTOs.Request;
using student_management_backend.DTOs.Response;
using student_management_backend.Core.Models;

namespace student_management_backend.Controllers;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly NeonDbContext _context;
    public ReviewController(NeonDbContext context)
    {
        _context = context;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateReview([FromBody]CreateReviewRequest body)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == body.SubmitId) ?? throw new NotFoundException("Submit doesn't exist");

        var review = new Review()
        { 
            Score = body.Score,
            SubmitId = body.SubmitId,
            TeacherId = body.TeacherId,
            Comment = body.Comment,
        };

        await _context.Review.AddAsync(review);
        await _context.SaveChangesAsync();
        return Ok(review.Id);
    }

    [HttpPut("{reviewId:int}")]
    public async Task<IActionResult> UpdateReview(int reviewId, [FromBody]UpdateReviewRequest body)
    {
        var review = await _context.Review.FirstOrDefaultAsync(x => x.Id == reviewId) ?? throw new NotFoundException("Review doesn't exist");
        var entry = _context.Entry(review);
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

        return Ok(review.Id);
    }

    [HttpGet("{reviewId:int}")]
    public async Task<ReviewResponse> GetReivew(int reviewId)
    {
        var review = await _context.Review
            .Where(x => x.Id == reviewId)
            .Include(x => x.User)
            .Select(x => new ReviewResponse()
            {
                Id = x.Id,
                Score = x.Score,
                Teacher = new UserResponse()
                {
                    Id = x.User.Id,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    AvatarUrl = x.User.AvatarUrl,
                }
            }).FirstOrDefaultAsync() ?? throw new NotFoundException("Review doesn't exist");

        return review;
    }

    [HttpGet("submit/{submitId:int}")]
    public async Task<ReviewResponse> GetReviewBySubmitId(int submitId)
    {
        var submit = await _context.Submit.FirstOrDefaultAsync(x => x.Id == submitId) ?? throw new NotFoundException("Submit doesn't exist");
        
        var review = await _context.Review
            .Where(x => x.SubmitId == submitId)
            .Include(x => x.User)
            .Select(x => new ReviewResponse()
            {
                Id = x.Id,
                Score = x.Score,
                Teacher = new UserResponse()
                {
                    Id = x.User.Id,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    AvatarUrl = x.User.AvatarUrl,
                }
            }).FirstOrDefaultAsync() ?? throw new NotFoundException("Review doesn't exist");

        return review;
    }

    [HttpGet("assignment/{assignmentId:int}")]
    public async Task<ICollection<ReviewResponse>> GetListReviewsByAssignmentId(int assignmentId)
    {
        var assignment = await _context.Assignment.FirstOrDefaultAsync(x => x.Id == assignmentId) ?? throw new NotFoundException("Assignment doesn't exist");

        var reviews = await _context.Review
            .Include(x => x.Submit)
            .Include(x => x.User)
            .Where(x => x.Submit.AssignmentId == assignmentId)
            .Select(x => new ReviewResponse()
            {
                Id = x.Id,
                Score = x.Score,
                Teacher = new UserResponse()
                {
                    Id = x.User.Id,
                    Email = x.User.Email,
                    FullName = x.User.FullName,
                    AvatarUrl = x.User.AvatarUrl,
                }
            })
            .ToListAsync();

        return reviews;
    }
}

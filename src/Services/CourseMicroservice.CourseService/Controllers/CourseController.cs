using CourseMicroservice.CourseService.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CourseMicroservice.CourseService.Controllers;

[Route("api/course")]
public class CourseController : Controller
{
    private readonly ILogger _logger;
    public CourseController(ILogger logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{userId}/courses")]
    [Authorize("course.read")]
    public async Task<IActionResult> GetCoursesCreatedByUserWithId(string userId)
    {
        List<CourseModel> allCourse= Db.Courses.AsQueryable()
            .Where(t => t.OwnerId == userId)
            .ToList<CourseModel>();
        return Ok(allCourse);
    }

    [HttpGet("{courseId}")]
    [Authorize("course.read")]
    public async Task<IActionResult> GetCourseWithOurId(string courseId)
    {
        var result = await Db.Courses.Find(t => t.Id.ToString() == courseId).FirstOrDefaultAsync();
        if (result == null)
        {
            return NotFound();
        }

        result.ViewNumber++;
        //Db.Courses.UpdateOne(t => t.Id.ToString() == courseId, result);
        return Ok(result);
    }
    
    

    [HttpPost]
    [Authorize("course.create")]
    public async Task<IActionResult> PostCourse([FromBody] Models.CreateCourse createCourse)
    {
        Models.CourseModel newCourse = new CourseModel()
        {
            BannerUrl = null,
            Content = createCourse.Content,
            CreatedAt = DateTime.UtcNow,
            Description = createCourse.Description,
            Id = Guid.NewGuid(),
            Name = createCourse.Name,
            //OwnerId =  à voirs
        };
        await Db.Courses.InsertOneAsync(newCourse);
        return Ok();
    }
    
}


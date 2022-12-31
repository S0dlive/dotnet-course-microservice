using CourseMicroservice.CourseService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CourseMicroservice.CourseService.Controllers;

[Route("api/course")]
public class CourseController
{
    private CourseDbContext _courseDbContext;
    public CourseController()
    {
        
    }
    [HttpGet]
    [Authorize("course.read")]
    public async Task<IActionResult> GetCourse()
    {
        throw new NotImplementedException();
    }
    
    [Authorize("course.create")]
    [HttpPost]
    public async Task<IActionResult> CreateCourseAsync()
    {
        throw new NotImplementedException();
    }
    
}


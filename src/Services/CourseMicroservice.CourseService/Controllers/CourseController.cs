using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CourseMicroservice.CourseService.Controllers;

[Route("api/course")]
public class CourseController
{
    [HttpGet]
    [Authorize("course.read")]
    public async Task<IActionResult> GetCourse()
    {
        
    }
}


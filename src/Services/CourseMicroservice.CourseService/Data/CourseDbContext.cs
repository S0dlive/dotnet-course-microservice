using System.Data.Common;
using CourseMicroservice.CourseService.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseMicroservice.CourseService.Data;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
    
    }
    
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CourseModel> Courses { get; set; }
    
}
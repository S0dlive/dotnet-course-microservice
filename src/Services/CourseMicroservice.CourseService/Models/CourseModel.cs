namespace CourseMicroservice.CourseService.Models;

public class CourseModel
{
    public string Name { get; set; }
    public string BannerUrl { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string OwnerId { get; set; }
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public uint ViewNumber { get; set; }
}

public class Comments
{
    public string CourseId { get; set; }
    public Guid CommentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Content { get; set; }
    public string OwnerId { get; set; }
    public uint LikeNumber { get; set; }
}


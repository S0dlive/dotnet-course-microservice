using CourseMicroservice.CourseService.Models;
using MongoDB.Driver;

public static class Db
{
    public static MongoClient Client = new MongoClient();
    public static IMongoDatabase DatabaseBase = Client.GetDatabase("database");
    public static IMongoCollection<CourseModel> Courses = DatabaseBase.GetCollection<CourseModel>("courses");
    public static IMongoCollection<Comment> Comments = DatabaseBase.GetCollection<Comment>("comments");
}
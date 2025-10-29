using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Persistence
{
    public class CourseHubContext : DbContext
    {
        public CourseHubContext(DbContextOptions<CourseHubContext> options)
             : base(options)
        {
        }
        
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Course_Category> Course_Categories{ get; set; }
        public DbSet<Course_Teacher> Course_Teachers{ get; set; }

    }
}

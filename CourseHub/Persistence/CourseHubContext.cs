using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using CourseHub.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Persistence
{
    public class CourseHubContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.ApplyConfigurationsFromAssembly(typeof(CourseHubContext).Assembly);

        }
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

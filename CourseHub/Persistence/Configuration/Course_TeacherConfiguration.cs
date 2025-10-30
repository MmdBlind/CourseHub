using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Persistence.Configuration
{
    public class Course_TeacherConfiguration : IEntityTypeConfiguration<Course_Teacher>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course_Teacher> builder)
        {
            builder.HasKey(ct => new { ct.CourseID, ct.TeacherID });
            builder.HasOne(c=>c.Course)
                   .WithMany(c => c.Course_Teachers)
                   .HasForeignKey(ct => ct.CourseID);
            builder.HasOne(c => c.Teacher)
                   .WithMany(c => c.Course_Teachers)
                   .HasForeignKey(ct => ct.TeacherID);
        }
    }
}

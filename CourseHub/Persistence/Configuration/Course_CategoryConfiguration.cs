using CourseHub.Models.CourseDB;
using CourseHub.Models.CourseHubDB;
using Microsoft.EntityFrameworkCore;

namespace CourseHub.Persistence.Configuration
{
    public class Course_CategoryConfiguration : IEntityTypeConfiguration<Course_Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course_Category> builder)
        {
            builder.HasKey(c => new { c.CourseID, c.CategoryID });
            builder.HasOne(c => c.Course)
                   .WithMany(cc => cc.Course_Categories)
                   .HasForeignKey(f => f.CourseID);
            builder.HasOne(c => c.Category)
                   .WithMany(cc => cc.Course_Categories)
                   .HasForeignKey(f => f.CategoryID);
        }
    }
}

using CourseHub.Models.CourseDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseHub.Persistence.Mapping
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseID);
            builder.Property(c => c.CourseTitle)
                   .IsRequired()
                   .HasMaxLength(60);
            builder.HasIndex(c => c.CourseSlug)
                   .HasDatabaseName("IX_Course_CourseSlug")
                   .IsUnique();
        }
    }
}

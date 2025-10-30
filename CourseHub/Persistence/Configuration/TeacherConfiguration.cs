using CourseHub.Models.CourseHubDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseHub.Persistence.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(c => c.TeacherID);
            builder.Property(c => c.TeacherFullName)
                   .IsRequired()
                   .HasMaxLength(120);
            builder.Property(c => c.TeacherBio)
                   .HasMaxLength(500);
        }
    }
}

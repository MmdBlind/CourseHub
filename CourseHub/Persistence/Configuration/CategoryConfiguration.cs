using CourseHub.Models.CourseHubDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseHub.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryID);
            builder.HasIndex(c => c.CategorySlug)
                   .HasDatabaseName("IX_Cours_CategorySlug")   
                   .IsUnique();
            builder.HasOne<Category>().WithMany().HasForeignKey(c => c.CategoryParentID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

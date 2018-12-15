using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Models
{
    public class DocumentCategoryConfiguration : IEntityTypeConfiguration<DocumentCategory>
    {
        public void Configure(EntityTypeBuilder<DocumentCategory> builder)
        {
            builder.HasKey(dc => new { dc.DocumentId, dc.CategoryId });
            builder.HasOne(dc => dc.Document)
                .WithMany(b => b.DocumentCategories)
                .HasForeignKey(bc => bc.DocumentId);
            builder.HasOne(dc => dc.Category)
                .WithMany(c => c.DocumentCategories)
                .HasForeignKey(dc => dc.CategoryId);
        }
    }
}
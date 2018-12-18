using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Models
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasOne(d => d.Category)
                .WithMany(d => d.Documents)
                .IsRequired();
            builder.HasIndex(d => d.Code)
            .IsUnique();
        }
    }
}
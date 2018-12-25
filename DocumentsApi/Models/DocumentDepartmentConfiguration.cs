using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DocumentsApi.Models
{
    public class DocumentDepartmentConfiguration : IEntityTypeConfiguration<DocumentDepartment>
    {
        public void Configure(EntityTypeBuilder<DocumentDepartment> builder)
        {
            builder.HasKey(dd => new { dd.DocumentId, dd.DepartmentId });
            builder.HasOne(dd => dd.Document)
                .WithMany(d => d.DocumentDepartments)
                .HasForeignKey(dd => dd.DocumentId)
                .IsRequired();
            builder.HasOne(dd => dd.Department)
                .WithMany(d => d.DocumentDepartments)
                .HasForeignKey(dd => dd.DepartmentId)
                .IsRequired();
        }
    }
}
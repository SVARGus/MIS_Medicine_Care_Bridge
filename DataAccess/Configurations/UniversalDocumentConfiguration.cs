using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class UniversalDocumentConfiguration : IEntityTypeConfiguration<UniversalDocumentEntity>
    {
        public void Configure(EntityTypeBuilder<UniversalDocumentEntity> builder)
        {
            builder.ToTable("universal_documents");
            builder.HasKey(ud => ud.Id);

            builder.Property(ud => ud.Id)
                .HasColumnName("id");

            builder.Property(ud => ud.Num)
                .HasColumnName("num")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ud => ud.DocumentName)
                .HasColumnName("document_name")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(ud => ud.Description)
                .HasColumnName("description")
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(ud => ud.DateOfIssue)
                .HasColumnName("date_of_issue")
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasOne(ud => ud.User)
                .WithMany(u => u.UniversalDocuments)
                .HasForeignKey(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ud => ud.DocumentType)
                .WithMany()
                .HasForeignKey(ud => ud.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

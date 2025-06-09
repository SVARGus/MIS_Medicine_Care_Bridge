using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class InsuranceDocumentConfiguration : IEntityTypeConfiguration<InsuranceDocumentEntity>
    {
        public void Configure(EntityTypeBuilder<InsuranceDocumentEntity> builder)
        {
            builder.ToTable("insurance_documents");
            // Составной PK = (UserId, Num) либо по UserId
            builder.HasKey(i => new { i.UserId, i.Num });

            builder.Property(p => p.Num)
                .HasColumnName("num");

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasOne(i => i.User)
                .WithOne(u => u.InsuranceDocument)
                .HasForeignKey<InsuranceDocumentEntity>(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.DocumentType)
                .WithMany()
                .HasForeignKey(i => i.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

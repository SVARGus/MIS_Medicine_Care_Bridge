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
            builder.HasKey(i => i.UserId);

            builder.Property(p => p.DocumentName)
                .HasColumnName("document_name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Num)
                .HasColumnName("num")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasIndex(dt => dt.Num)
                .IsUnique();

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

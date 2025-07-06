using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeEntity> builder)
        {
            builder.ToTable("document_type");
            builder.HasKey(dt => dt.Id);

            builder.Property(dt => dt.Id)
                .HasColumnName("id");

            builder.Property(dt => dt.NameType)
                .HasColumnName("name_type")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(dt => dt.NameType)
                .IsUnique();

            // Связь m:n с UserEntity через UserDocumentTypeEntity
            builder.HasMany(dt => dt.UserDocumentTypes)
                .WithOne(udt => udt.DocumentType)
                .HasForeignKey(udt => udt.DocumentTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

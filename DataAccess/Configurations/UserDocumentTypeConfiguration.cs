using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class UserDocumentTypeConfiguration : IEntityTypeConfiguration<UserDocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<UserDocumentTypeEntity> builder)
        {
            builder.ToTable("user_document_types");
            builder.HasKey(udt => new { udt.UserId, udt.DocumentTypeId });

            builder.Property(ur => ur.UserId)
                .HasColumnName("user_id");

            builder.Property(ur => ur.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasOne(udt => udt.User)
                .WithMany(u => u.UserDocumentTypes)
                .HasForeignKey(udt => udt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(udt => udt.DocumentType)
                .WithMany(dt => dt.UserDocumentTypes)
                .HasForeignKey(udt => udt.DocumentTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class SnilsConfiguration : IEntityTypeConfiguration<SnilsEntity>
    {
        public void Configure(EntityTypeBuilder<SnilsEntity> builder)
        {
            builder.ToTable("snils");
            builder.HasKey(s => s.NumSnils);

            builder.Property(p => p.NumSnils)
                .HasColumnName("num_snils");

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasOne(s => s.User)
                .WithOne(u => u.Snils)
                .HasForeignKey<SnilsEntity>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.DocumentType)
                .WithMany()
                .HasForeignKey(s => s.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

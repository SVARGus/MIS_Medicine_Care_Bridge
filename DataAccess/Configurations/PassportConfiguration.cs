using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<PassportEntity>
    {
        public void Configure(EntityTypeBuilder<PassportEntity> builder)
        {
            builder.ToTable("passports");
            // Составной PK = (UserId, PassportNum) или можно PK по UserId только, если один паспорт на пользователя
            builder.HasKey(p => new { p.UserId, p.PassportNum });

            builder.Property(p => p.PassportNum)
                .HasColumnName("passport_num");

            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.Info)
                .HasColumnName("info")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.DateOfIssue)
                .HasColumnName("date_od_issue")
                .IsRequired();

            builder.Property(ur => ur.DocumentTypeId)
                .HasColumnName("document_type_id");

            builder.HasOne(p => p.User)
                .WithOne(u => u.Passport)
                .HasForeignKey<PassportEntity>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.DocumentType)
                .WithMany()
                .HasForeignKey(p => p.DocumentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

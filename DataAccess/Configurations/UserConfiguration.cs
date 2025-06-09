using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Login)
                .HasColumnName("login")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(200);

            // Уникальный индекс на Login
            builder.HasIndex(u => u.Login)
                .IsUnique();

            // 1:1 с PersonalDataEntity
            builder.HasOne(u => u.PersonalData)
                   .WithOne(pd => pd.User)
                   .HasForeignKey<PersonalDataEntity>(pd => pd.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:0..1 с PassportEntity
            builder.HasOne(u => u.Passport)
                   .WithOne(p => p.User)
                   .HasForeignKey<PassportEntity>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:0..1 с SnilsEntity
            builder.HasOne(u => u.Snils)
                   .WithOne(s => s.User)
                   .HasForeignKey<SnilsEntity>(s => s.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:0..1 с InsuranceDocumentEntity
            builder.HasOne(u => u.InsuranceDocument)
                   .WithOne(i => i.User)
                   .HasForeignKey<InsuranceDocumentEntity>(i => i.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 1:N с UniversalDocumentEntity
            builder.HasMany(u => u.UniversalDocuments)
                   .WithOne(ud => ud.User)
                   .HasForeignKey(ud => ud.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // m:n с RoleEntity через UserRoleEntity
            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // m:n с DocumentTypeEntity через UserDocumentTypeEntity
            builder.HasMany(u => u.UserDocumentTypes)
                   .WithOne(ud => ud.User)
                   .HasForeignKey(ud => ud.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

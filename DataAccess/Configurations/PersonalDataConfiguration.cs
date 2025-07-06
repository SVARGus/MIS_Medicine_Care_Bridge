using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class PersonalDataConfiguration : IEntityTypeConfiguration<PersonalDataEntity>
    {
        public void Configure(EntityTypeBuilder<PersonalDataEntity> builder)
        {
            builder.ToTable("personal_data");
            builder.HasKey(pd => pd.UserId);

            builder.Property(pd => pd.UserId)
                .HasColumnName("user_id");

            builder.Property(pd => pd.FirstName)
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pd => pd.LastName)
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(bd => bd.MiddleName)
                .HasColumnName("middle_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(bd => bd.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired();

            builder.Property(pd => pd.Phone)
                .HasColumnName("phone")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(pd => pd.Email)
                .HasColumnName("email")
                .HasMaxLength(100);

            // 1:1 с UserEntity
            builder.HasOne(pd => pd.User)
                .WithOne(u => u.PersonalData)
                .HasForeignKey<PersonalDataEntity>(pd => pd.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

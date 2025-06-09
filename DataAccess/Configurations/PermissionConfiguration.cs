using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicineCareBridge.DataAccess.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("permissions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Text)
                .HasColumnName("text")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.IsAllowed)
                .HasColumnName("allowed")
                .IsRequired();

            // m:n с RoleEntity через RolePermissionEntity
            builder.HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

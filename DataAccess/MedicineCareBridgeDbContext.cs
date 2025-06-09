using MedicineCareBridge.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using MedicineCareBridge.DataAccess.Extensions;

namespace MedicineCareBridge.DataAccess
{
    public class MedicineCareBridgeDbContext : DbContext
    {
        public MedicineCareBridgeDbContext(DbContextOptions<MedicineCareBridgeDbContext> options)
            : base(options) { }

        // DbSet для «плоских» сущностей
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<RoleEntity> Roles { get; set; } = null!;
        public DbSet<PermissionEntity> Permissions { get; set; } = null!;
        public DbSet<DocumentTypeEntity> DocumentTypes { get; set; } = null!;

        // Промежуточные таблицы m:n
        public DbSet<UserRoleEntity> UserRoles { get; set; } = null!;
        public DbSet<RolePermissionEntity> RolePermissions { get; set; } = null!;
        public DbSet<UserDocumentTypeEntity> UserDocumentTypes { get; set; } = null!;

        // Сущности «1:1» / «1:N»
        public DbSet<PersonalDataEntity> PersonalData { get; set; } = null!;
        public DbSet<PassportEntity> Passports { get; set; } = null!;
        public DbSet<SnilsEntity> Snils { get; set; } = null!;
        public DbSet<InsuranceDocumentEntity> InsuranceDocuments { get; set; } = null!;
        public DbSet<UniversalDocumentEntity> UniversalDocuments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Автоматически применяем все конфигурации из папки Configurations
            modelBuilder.ApplyAllConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}

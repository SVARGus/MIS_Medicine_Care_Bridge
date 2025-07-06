using Microsoft.EntityFrameworkCore;
using MedicineCareBridge.DataAccess.Repositories.Implementations;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicineCareBridge.DataAccess.Extensions
{
    // Позже данный клас переесем в серверную часть проекта + appsettings.json со строкой подключения (пример ниже)
    //{
    //    "ConnectionStrings": 
    //    {
    //        "DefaultConnection": "Host=localhost;Port=5432;Database=MedicineCare;Username=youruser;Password=yourpass"
    //    }
    //}
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            // 1) Регистрация DbContext
            services.AddDbContext<MedicineCareBridgeDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // 2) Регистрация репозиториев
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IPassportRepository, PassportRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<ISnilsRepository, SnilsRepository>();
            services.AddScoped<IInsuranceDocumentRepository, InsuranceDocumentRepository>();
            services.AddScoped<IUniversalDocumentRepository, UniversalDocumentRepository>();
            services.AddScoped<IUserDocumentTypeRepository, UserDocumentTypeRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

            return services;
        }
    }
}

using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Server.Services.Implementations;

namespace MedicineCareBridge.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Регистрирует все сервисы бизнес‑логики (IAuthService, IUserService, …).
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPassportService, PassportService>();
            services.AddScoped<ISnilsService, SnilsService>();
            services.AddScoped<IInsuranceDocumentService, InsuranceDocumentService>();
            services.AddScoped<IUniversalDocumentService, UniversalDocumentService>();
            return services;
        }
    }
}

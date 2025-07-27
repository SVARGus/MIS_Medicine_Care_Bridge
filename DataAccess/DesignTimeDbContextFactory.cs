using MedicineCareBridge.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MedicineCareBridge.DataAccess
{
    /// <summary>
    /// Фабрика для создания DbContext во время выполнения инструментов EF Core CLI.
    /// </summary>
    public class DesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<MedicineCareBridgeDbContext>
    {
        public MedicineCareBridgeDbContext CreateDbContext(string[] args)
        {
            // 1) Читаем appsettings.json из папки Server/Configuration
            var settingsPath = Path.Combine(
                Directory.GetCurrentDirectory(),  // DataAccess
                "..",                             // корень решения
                "MedicineCareBridge.Server",
                "Configuration"
            );
            var config = new ConfigurationBuilder()
                .SetBasePath(settingsPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            // 2) Получаем строку подключения
            var connectionString = config
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found in appsettings.json");

            // 3) Создаём builder с Npgsql и указываем схему для истории миграций
            var optionsBuilder = new DbContextOptionsBuilder<MedicineCareBridgeDbContext>();
            optionsBuilder.UseNpgsql(
                connectionString,
                npgsqlOptions => npgsqlOptions
                    .MigrationsHistoryTable(
                        tableName: "__EFMigrationsHistory",
                        schema: "medicinecarebridge"  // ваша схема
                    )
            );

            return new MedicineCareBridgeDbContext(optionsBuilder.Options);
        }
    }
}
using MedicineCareBridge.DataAccess;
using Microsoft.EntityFrameworkCore;
//using MedicineCareBridge.Server.Mappings;
//using MedicineCareBridge.Server.Middlewares;
using Microsoft.OpenApi.Models; // Swagger-конфигурация для документирования API модели

var builder = WebApplication.CreateBuilder(args);

// 1. Настройка конфигураций
var configuration = builder.Configuration;

// 2. Регистрация сервисов
// 2.1 Контроллеры Web API
builder.Services.AddControllers();

// 2.2. Swagger / OpenAPI (для документации API)
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "MedicineCareBridge API",
//        Version = "v1",
//        Description = "Сервис управления медицинскими данными"
//    });
//});

// 3. Настройка и регистрация БД и EF Core
builder.Services.AddDbContext<MedicineCareBridgeDbContext>(options =>
    options.UseNpgsql(
        configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")
    )
);

// 4. AutoMapper
//builder.Services.AddAutoMapper(typeof(MappingProfile));

// 5. Свои сервисы (DI)
//builder.Services.Scan(scan => scan
//    .FromAssemblyOf<Program>()
//    .AddClasses(classes => classes
//        .InNamespaces("MedicineCareBridge.Server.Services.Implementations")
//    )
//    .AsImplementedInterfaces()
//    .WithScopedLifetime()
//);

// 6. Docker и конфигурации
// Уже задано: Linux, порты 8080/8081 в Dockerfile

var app = builder.Build();

// 7. Middleware-пайплайн или кастомный Middleware (логирование ошибок)


app.Run();

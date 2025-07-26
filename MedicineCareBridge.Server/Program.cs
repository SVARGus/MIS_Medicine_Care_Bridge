using MedicineCareBridge.DataAccess;
using Microsoft.EntityFrameworkCore;
using MedicineCareBridge.Server.Mappings;
using MedicineCareBridge.Server.Services.Interfaces;
using MedicineCareBridge.Server.Services.Implementations;
using MedicineCareBridge.Server.Extensions;
//using MedicineCareBridge.Server.Middlewares;
using MedicineCareBridge.DataAccess.Repositories.Interfaces;
using MedicineCareBridge.DataAccess.Repositories.Implementations;
using MedicineCareBridge.DataAccess.Extensions;
using Microsoft.OpenApi.Models; // Swagger-конфигурация для документирования API модели
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;         // для расширений AddSwaggerGen и AddAuthentication
using Microsoft.OpenApi.Models;                        // для OpenApiInfo

var builder = WebApplication.CreateBuilder(args);

// 1. Настройка конфигураций
var configuration = builder.Configuration;

// 2. Регистрация сервисов
// 2.1 Контроллеры Web API
builder.Services.AddControllers();

// 2.2. Swagger / OpenAPI (для документации API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MedicineCareBridge API",
        Version = "v1",
        Description = "Сервис управления медицинскими данными"
    });
});

// 3. Настройка и регистрация БД и EF Core
builder.Services.AddDbContext<MedicineCareBridgeDbContext>(options =>
    options.UseNpgsql(
        configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")
    )
);

// 4. AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// 5. Аутентификация / JWT
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = configuration["Jwt:Authority"];
        options.Audience = configuration["Jwt:Audience"];
        // другие настройки (ключи, валидация и т.п.)
    });
builder.Services.AddAuthorization();

// 6. Регистрация репозиториев (DataAccess) и сервисов (Server.Services)
builder.Services
    .AddDataAccessServices(configuration)   // из DataAccess.Extensions
    .AddApplicationServices();             // из Server.Extensions

// 7. Docker и конфигурации
// Уже задано: Linux, порты 8080/8081 в Dockerfile

var app = builder.Build();

// 8. Middleware-пайплайн или кастомный Middleware (логирование ошибок)

// Включаем Swagger в деве (и/или проде, если нужно)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicineCareBridge API v1"));
}

app.UseRouting();

// Аутентификация / авторизация
app.UseAuthentication();
app.UseAuthorization();

// Маршрутизация контроллеров
app.MapControllers();

app.Run();

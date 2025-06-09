# Медицинская Информационная Система (МИС) "Medicine Care Bridge"

## Содержание
- [Технологический стек](#технологический-стек)
- [Общее решение](#общее-решение)
- [Структура проекта (псевдодерево)](#структура-проекта-псевдодерево)
- [Команда проекта](#команда-проекта)

## Технологический стек

- WPF (графический интерфейс)
- ASP.NET Core (серверная часть)
- PostgraseSQL (база данных
- xUnit (unit tests)
- GitHab (система контроля версий)
- Entity FR Core (контекст БД, миграция и репозитории)
- C# (.NET 8.0)
- Doxygen(документирование кода)
- UML (диаграммы)

## Общее решение

```text
MedicineCareBridge.sln
│
├── src
│   ├── MedicineCareBridge.Client           (WPF-приложение, MVVM)
│   ├── MedicineCareBridge.Server           (ASP.NET Core Web API)
│   ├── MedicineCareBridge.DataAccess       (EF Core, репозитории, миграции)
│   ├── MedicineCareBridge.Domain           (доменные сущности, бизнес-логика)
│   ├── MedicineCareBridge.Shared           (DTO, общие интерфейсы, перечисления)
│
└── tests
    ├── MedicineCareBridge.Tests            (xUnit-тесты для сервисов и DataAccess)
    └── MedicineCareBridge.ClientTests      (при необходимости unit-тесты ViewModels)
```
- MedicineCareBridge.Client — клиентское WPF-приложение, построенное по паттерну MVVM.
- MedicineCareBridge.Server — серверная часть на ASP.NET Core, отвечает за авторизацию/аутентификацию, бизнес-логику, предоставление REST API.
- MedicineCareBridge.DataAccess — класс-библиотека с EF Core («Entity Framework Core») для работы с PostgreSQL: контекст БД, миграции, репозитории.
- MedicineCareBridge.Domain — доменные модели (сущности, валидация, бизнес-правила), которые могут использоваться как на клиенте (только чтение/валидация) и на сервере.
- MedicineCareBridge.Shared — общие для клиента и сервера DTO (Data Transfer Objects), интерфейсы сервисов, перечисления ролей, константы. Здесь же можно держать контракты (например, интерфейсы для SignalR, если в будущем понадобится мессенджер).
- MedicineCareBridge.Tests — модуль с xUnit-тестами для проверок бизнес-логики (Domain/Server) и DataAccess.
- MedicineCareBridge.ClientTests — (опционально) модуль с тестами ViewModels (с моками сервисов).

## Структура проекта (псевдодерево)

```text
MedicineCareBridge.sln
│
├── src
│   ├── MedicineCareBridge.Client
│   │   ├── Views
│   │   ├── ViewModels
│   │   ├── Models
│   │   ├── Services
│   │   ├── Helpers
│   │   ├── Resources
│   │   └── Utilities
│   │
│   ├── MedicineCareBridge.Server
│   │   ├── Controllers
│   │   ├── Services
│   │   │   ├── Interfaces
│   │   │   └── Implementations
│   │   ├── DTOs
│   │   │   ├── Auth
│   │   │   ├── User
│   │   │   ├── Patient
│   │   │   ├── Appointment
│   │   │   └── MedicalRecord
│   │   ├── Mappings
│   │   ├── Middlewares
│   │   ├── Configuration
│   │   ├── Extensions
│   │   ├── Domain (ссылка на MedicineCareBridge.Domain)
│   │   └── DataAccess (ссылка на MedicineCareBridge.DataAccess)
│   │
│   ├── MedicineCareBridge.DataAccess
│   │   ├── MedicineCareBridgeDbContext.cs
│   │   ├── Entities
│   │   ├── Configurations
│   │   ├── Repositories
│   │   │   ├── Interfaces
│   │   │   └── Implementations
│   │   ├── Migrations
│   │   └── Extensions
│   │
│   ├── MedicineCareBridge.Domain
│   │   ├── Entities
│   │   ├── ValueObjects
│   │   ├── Enums
│   │   ├── Exceptions
│   │   └── Services (Domain-level, если нужны)
│   │
│   └── MedicineCareBridge.Shared
│       ├── DTOs
│       │   ├── Auth
│       │   ├── User
│       │   ├── Patient
│       │   ├── Appointment
│       │   ├── MedicalRecord
│       │   └── Shared
│       ├── Interfaces
│       ├── Enums
│       └── Utilities
│
└── tests
    ├── MedicineCareBridge.Tests
    │   ├── DataAccessTests
    │   ├── ServiceTests
    │   ├── DomainTests
    │   └── TestHelpers
    └── MedicineCareBridge.ClientTests  (опционально)
```

## Команда проекта
- [Кузнецов Павел](https://github.com/SVARGus) - Основной разработчик 
- [Беляев Иван](https://github.com/Ivan255Mhz) - Основной разработчик

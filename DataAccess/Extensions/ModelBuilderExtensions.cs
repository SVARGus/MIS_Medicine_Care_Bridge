using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MedicineCareBridge.DataAccess.Extensions
{
    /// <summary>
    /// Расширение для ModelBuilder: автоматически находит и применяет все IEntityTypeConfigurations из сборки
    /// </summary>
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            // Ищем все типы, реализующие IEntityTypeConfiguration<T>
            var applyGenericMethod = typeof(ModelBuilder)
                .GetMethods()
                .First(m =>
                    m.Name == nameof(ModelBuilder.ApplyConfiguration)
                    && m.GetParameters().Length == 1);

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t =>
                    t.GetInterfaces().Any(i =>
                        i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var type in typesToRegister)
            {
                var interfaceType = type.GetInterfaces()
                    .First(i =>
                        i.IsGenericType
                        && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
                var entityType = interfaceType.GetGenericArguments()[0];
                var configurationInstance = Activator.CreateInstance(type);
                var genericApplyConfigMethod = applyGenericMethod.MakeGenericMethod(entityType);
                genericApplyConfigMethod.Invoke(modelBuilder, new[] { configurationInstance });
            }
        }
    }
}

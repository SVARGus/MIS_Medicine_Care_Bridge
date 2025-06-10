using System.Text.RegularExpressions;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Представляет объект-значение для электронной почты с валидацией
    /// </summary>
    /// <remarks>
    /// <para>
    /// Реализует строгую проверку формата email при создании объекта.
    /// Гарантирует, что все экземпляры класса содержат валидные email-адреса.
    /// </para>
    /// <para>
    /// Класс является:
    /// - <b>Sealed</b>: Запрещено наследование для сохранения контроля валидации
    /// - <b>Immutable</b>: Значение не может быть изменено после создания
    /// - <b>Value Object</b>: Сравнение происходит по значению, а не поссылке
    /// </para>
    /// </remarks>
    public sealed class Email
    {
        /// <summary>
        /// Строковое значение email-адреса
        /// </summary>
        /// <value>
        /// Валидный email-адрес в формате "локальная_часть@домен.топ_домен"
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Инициализирует новый экземпляр Email
        /// </summary>
        /// <param name="value">Строка для валидации и преобразования в email</param>
        /// <exception cref="DomainException">
        /// Выбрасывается при:
        /// - Пустой строке или null
        /// - Несоответствии формату email
        /// </exception>
        /// <example>
        /// <code>
        /// var validEmail = new Email("user@example.com");
        /// var invalidEmail = new Email("invalid"); // Выбрасывает DomainException
        /// </code>
        /// </exception>
        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new DomainException($"«{value}» не валидный email.");
            }
            Value = value;
        }

        /// <summary>
        /// Определяет равенство объектов Email по значению
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>
        /// true если:
        /// - obj является типом Email
        /// - Значение Value совпадает
        /// </returns>
        public override bool Equals(object? obj) => obj is Email other  && Value == other.Value;

        /// <summary>
        /// Возвращает хэш-код на основе значения email
        /// </summary>
        /// <returns>
        /// Целочисленный хэш-код вычисленный из свойства Value
        /// </returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Возвращает строковое представление email
        /// </summary>
        /// <returns>
        /// Строковое значение email в формате, предоставленном при создании
        /// </returns>
        public override string ToString() => Value;
    }
}

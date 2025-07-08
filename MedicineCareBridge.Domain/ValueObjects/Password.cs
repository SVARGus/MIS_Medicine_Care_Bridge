using System.Text.RegularExpressions;
using MedicineCareBridge.Domain.Exceptions;

namespace MedicineCareBridge.Domain.ValueObjects
{
    /// <summary>
    /// Представляет объект‑значение для пароля с валидацией по строгим правилам.
    /// </summary>
    /// <remarks>
    /// <para>
    /// При создании выполняется проверка, что пароль:
    /// <list type="bullet">
    ///   <item><description>Содержит не менее 8 символов;</description></item>
    ///   <item><description>Имеет хотя бы одну цифру;</description></item>
    ///   <item><description>Имеет хотя бы одну букву в верхнем регистре;</description></item>
    ///   <item><description>Имеет хотя бы одну букву в нижнем регистре;</description></item>
    ///   <item><description>Имеет хотя бы один специальный символ (не буква и не цифра).</description></item>
    /// </list>
    /// </para>
    /// <para>
    /// Класс является:
    /// - <b>Sealed</b>: запрещено наследование для сохранения контроля валидации;
    /// - <b>Immutable</b>: значение не может быть изменено после создания;
    /// - <b>Value Object</b>: сравнение происходит по значению, а не по ссылке.
    /// </para>
    /// </remarks>
    public sealed class Password
    {
        /// <summary>
        /// Валидированный пароль.
        /// </summary>
        /// <value>
        /// Строка длиной ≥ 8, содержащая цифру, спецсимвол, букву в верхнем и нижнем регистре.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Password"/>, выполняя валидацию.
        /// </summary>
        /// <param name="value">Пароль для проверки и сохранения.</param>
        /// <exception cref="DomainException">
        /// Выбрасывается в случаях:
        /// <list type="bullet">
        ///   <item><description><paramref name="value"/> == <c>null</c> или пустая строка;</description></item>
        ///   <item><description>Менее 8 символов;</description></item>
        ///   <item><description>Отсутствует цифра;</description></item>
        ///   <item><description>Отсутствует буква в верхнем регистре;</description></item>
        ///   <item><description>Отсутствует буква в нижнем регистре;</description></item>
        ///   <item><description>Отсутствует специальный символ (не буква, не цифра).</description></item>
        /// </list>
        /// </exception>
        /// <example>
        /// <code>
        /// var good = new Password("Abc!2345");    // проходит валидацию
        /// var bad  = new Password("abcdefg1");    // throws DomainException (нет Upper и спецсимвола)
        /// </code>
        /// </example>
        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException("Пароль не может быть пустым или null.");

            if (value.Length < 8)
                throw new DomainException("Пароль должен содержать не менее 8 символов.");

            if (!Regex.IsMatch(value, @"\d"))
                throw new DomainException("Пароль должен содержать хотя бы одну цифру.");

            if (!Regex.IsMatch(value, @"[A-Z]"))
                throw new DomainException("Пароль должен содержать хотя бы одну заглавную букву.");

            if (!Regex.IsMatch(value, @"[a-z]"))
                throw new DomainException("Пароль должен содержать хотя бы одну строчную букву.");

            if (!Regex.IsMatch(value, @"[^A-Za-z0-9]"))
                throw new DomainException("Пароль должен содержать хотя бы один специальный символ.");

            Value = value;
        }

        /// <summary>
        /// Определяет равенство объектов Password по значению
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>
        /// true если:
        /// - obj является типом Password
        /// - Значение Value совпадает
        /// </returns>
        public override bool Equals(object? obj) => obj is PhoneNumber other && Value == other.Value;

        /// <summary>
        /// Возвращает хэш-код на основе значения Password
        /// </summary>
        /// <returns>
        /// Целочисленный хэш-код вычисленный из свойства Value
        /// </returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Возвращает строковое представление Password
        /// </summary>
        /// <returns>
        /// Строковое значение Password в формате, предоставленном при создании
        /// </returns>
        public override string ToString() => Value;
    }
}

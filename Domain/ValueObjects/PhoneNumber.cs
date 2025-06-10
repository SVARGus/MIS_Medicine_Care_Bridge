using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Представляет объект-значение для телефона с валидацией
    /// </summary>
    /// <remarks>
    /// <para>
    /// При создании обрабатывает различные форматы российских номеров, например:
    /// +7 (921) 999-22-33, +7(921)9992233, 8 921 999-22-33 и т.п.,
    /// приводя их к виду +79219992233.
    /// </para>
    /// <para>
    /// Класс является:
    /// - <b>Sealed</b>: Запрещено наследование для сохранения контроля валидации
    /// - <b>Immutable</b>: Значение не может быть изменено после создания
    /// - <b>Value Object</b>: Сравнение происходит по значению, а не поссылке
    /// </para>
    /// </remarks>
    public sealed class PhoneNumber
    {
        /// <summary>
        /// Нормализованный номер телефона.
        /// </summary>
        /// <value>
        /// Всегда в формате <c>+7XXXXXXXXXX</c> (1 цифра «7» — код России + 10 цифр абонента).
        /// </value>
        public string Value { get;}

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PhoneNumber"/>, выполняя
        /// валидацию и нормализацию входной строки.
        /// </summary>
        /// <param name="value">
        /// Строка с номером телефона в одном из распространённых форматов:
        /// +7 (921) 999‑22‑33, +79219992233, 8‑921‑999‑22‑33 и т.п.
        /// </param>
        /// <exception cref="DomainException">
        /// Выбрасывается в случаях:
        /// <list type="bullet">
        ///   <item><description><paramref name="value"/> == <c>null</c> или пустая строка.</description></item>
        ///   <item><description>После удаления форматирующих символов не удалось привести к российскому номеру (+7).</description></item>
        /// </list>
        /// </exception>
        /// <example>
        /// <code>
        /// var a = new PhoneNumber("+7 (921) 999-22-33");   // Value = "+79219992233"
        /// var b = new PhoneNumber("8 921 9992233");        // Value = "+79219992233"
        /// var c = new PhoneNumber("+79219992233");         // Value = "+79219992233"
        /// var d = new PhoneNumber("123");                  // throws DomainException
        /// </code>
        /// </example>
        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new DomainException("Телефон не может быть пустым или null.");
            }

            var digits = Regex.Replace(value, @"\D", "");

            if (digits.Length == 11 && digits.StartsWith("8"))
            {
                digits = "7" + digits.Substring(1);
            }

            if (digits.Length != 11 || !digits.StartsWith("7"))
            {
                throw new DomainException($"Неверный формат номера телефона: '{value}'. Ожидается российский формат +7XXXXXXXXXX.");
            }

            Value = "+" + digits;
        }

        /// <summary>
        /// Определяет равенство объектов PhoneNumber по значению
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>
        /// true если:
        /// - obj является типом PhoneNumber
        /// - Значение Value совпадает
        /// </returns>
        public override bool Equals(object? obj) => obj is PhoneNumber other && Value == other.Value;

        /// <summary>
        /// Возвращает хэш-код на основе значения PhoneNumber
        /// </summary>
        /// <returns>
        /// Целочисленный хэш-код вычисленный из свойства Value
        /// </returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Возвращает строковое представление PhoneNumber
        /// </summary>
        /// <returns>
        /// Строковое значение PhoneNumber в формате, предоставленном при создании
        /// </returns>
        public override string ToString() => Value;
    }
}

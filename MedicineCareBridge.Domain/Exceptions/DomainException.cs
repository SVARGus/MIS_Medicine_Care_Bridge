namespace MedicineCareBridge.Domain.Exceptions
{
    /// <summary>
    /// Базовое доменное исключение - можно ловить сразу все DomainException'ы, или переопределять для конкретных кейсов.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DomainException"/> без сообщения.
        /// </summary>
        public DomainException() { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DomainException"/> с указаным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее причину ошибки</param>
        public DomainException(string message) : base(message) { }

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="DomainException"/> с указанным сообщением об ошибке
        /// и вложенным исключением, послужившим причиной текущего исключения.
        /// </summary>
        /// <param name="message">Сообщение, описывающее причину ошибки</param>
        /// <param name="innerException">Исключение, ставшее причиной текущего.</param>
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }
}

namespace MedicineCareBridge.Shared.DTO.Documents
{
    /// <summary>
    /// Универсальный DTO для произвольного документа пользователя.
    /// </summary>
    public class UniversalDocumentDto
    {
        /// <summary>
        /// Идентификатор документа (null при создании нового).
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Номер документа.
        /// </summary>
        public string Num { get; set; } = null!;

        /// <summary>
        /// Название документа.
        /// </summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>
        /// Описание или дополнительные сведения (необязательно).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Дата выдачи документа.
        /// </summary>
        public DateTime DateOfIssue { get; set; }
    }
}

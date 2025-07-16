namespace MedicineCareBridge.Shared.DTO.Documents
{
    /// <summary>
    /// DTO, представляющий паспорт гражданина.
    /// </summary>
    public class PassportDto
    {
        /// <summary>
        /// Название документа (например, "Паспорт РФ").
        /// </summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string PassportNum { get; set; } = null!;

        /// <summary>
        /// Дополнительная информация (например, кем выдан).
        /// </summary>
        public string Info { get; set; } = null!;

        /// <summary>
        /// Дата выдачи паспорта.
        /// </summary>
        public DateTime DateOfIssue { get; set; }
    }
}

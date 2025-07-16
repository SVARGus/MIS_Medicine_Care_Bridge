namespace MedicineCareBridge.Shared.DTO.Documents
{
    /// <summary>
    /// DTO для представления СНИЛС (страхового номера индивидуального лицевого счёта).
    /// </summary>
    public class SnilsDto
    {
        /// <summary>
        /// Название документа (например, "СНИЛС").
        /// </summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>
        /// Номер СНИЛС.
        /// </summary>
        public string NumSnils { get; set; } = null!;
    }
}

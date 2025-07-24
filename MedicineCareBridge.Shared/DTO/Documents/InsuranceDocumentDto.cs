namespace MedicineCareBridge.Shared.DTO.Documents
{
    /// <summary>
    /// DTO для представления полиса медицинского страхования.
    /// </summary>
    public class InsuranceDocumentDto
    {
        /// <summary>
        /// Название документа (например, "Полис ОМС").
        /// </summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>
        /// Номер страхового полиса.
        /// </summary>
        public string Num { get; set; } = null!;
    }
}

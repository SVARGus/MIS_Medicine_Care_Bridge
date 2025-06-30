namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица Passport (Паспортные данные пользователя)
    /// </summary>
    public class PassportEntity
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Номер паспорта</summary>
        public string PassportNum { get; set; } = string.Empty;

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Информация о паспорте (например, где выдан)</summary>
        public string Info { get; set; } = null!;

        /// <summary>Дата выдачи паспорта</summary>
        public DateTime DateOfIssue { get; set; }

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «Паспорт»)</summary>
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}

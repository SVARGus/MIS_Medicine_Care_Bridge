namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица Snils (СНИЛС пользователя)
    /// </summary>
    public class SnilsEntity
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; set; } = null!;

        /// <summary>Номер СНИЛС (PRIMARY KEY или составной с UserId)</summary>
        public string NumSnils { get; set; } = null!;

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «СНИЛС»)</summary>
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}

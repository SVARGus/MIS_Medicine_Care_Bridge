namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица Snils (СНИЛС пользователя)
    /// </summary>
    //[Table("snils")]
    //[PrimaryKey(nameof(NumSnils))]
    public class SnilsEntity
    {
        /// <summary>Номер СНИЛС (PRIMARY KEY или составной с UserId)</summary>
        //[Column("num_snils")]
        public int NumSnils { get; set; }

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «СНИЛС»)</summary>
        //[Column("document_type_id"), ForeignKey("document_type")]
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}

namespace MedicineCareBridge.DataAccess.Entities
{
    /// <summary>
    /// Таблица Passport (Паспортные данные пользователя)
    /// </summary>
    //[Table("pasport")]
    //[PrimaryKey(nameof(PassportNum))]
    public class PassportEntity
    {
        /// <summary>Название документа, соответствет типу документа (на русском)</summary>
        public string DocumentName { get; private set; } = string.Empty;

        /// <summary>Номер паспорта</summary>
        //[Column("passport_num")]
        public string PassportNum { get; set; } = string.Empty;

        /// <summary>Внешний ключ на UserEntity.Id</summary>
        //[Column("user_id"), ForeignKey("users")]
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        /// <summary>Информация о паспорте (например, где выдан)</summary>
        //[Column("info")]
        public string Info { get; set; } = null!;

        /// <summary>Дата выдачи паспорта</summary>
        //[Column("date_od_issue")]
        public DateTime DateOfIssue { get; set; }

        /// <summary>Внешний ключ на DocumentTypeEntity.Id (обычно «Паспорт»)</summary>
        //[Column("document_type_id"), ForeignKey("document_type")]
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity DocumentType { get; set; } = null!;
    }
}

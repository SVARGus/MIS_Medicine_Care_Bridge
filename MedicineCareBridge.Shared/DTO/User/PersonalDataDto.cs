namespace MedicineCareBridge.Shared.DTO.User
{
    /// <summary>
    /// DTO для личных данных пользователя.
    /// </summary>
    public class PersonalDataDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
    }
}

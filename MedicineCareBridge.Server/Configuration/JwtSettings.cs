namespace MedicineCareBridge.Server.Configuration
{
    /// <summary>
    /// Параметры генерации JWT-токена, берутся из appsettings.json.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>Секретная строка (ключ) для подписи токена.</summary>
        public string Secret { get; set; } = null!;

        /// <summary>Издатель токена (issuer).</summary>
        public string Issuer { get; set; } = null!;

        /// <summary>Потребитель токена (audience).</summary>
        public string Audience { get; set; } = null!;

        /// <summary>Время жизни токена в минутах.</summary>
        public int LifetimeMinutes { get; set; }
    }
}

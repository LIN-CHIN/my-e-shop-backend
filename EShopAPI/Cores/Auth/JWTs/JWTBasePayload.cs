using System.Text.Json.Serialization;

namespace EShopAPI.Cores.Auth.JWTs
{
    /// <summary>
    /// JWT 基本的Payload
    /// </summary>
    public class JwtBasePayload
    {
        /// <summary>
        /// JWT用戶(使用者帳號)
        /// </summary>
        [JsonPropertyName("sub")]
        public string Subject { get; set; } = null!;

        /// <summary>
        /// JWT簽發者
        /// </summary>
        [JsonPropertyName("iss")]
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// JWT簽發時間
        /// </summary>
        [JsonPropertyName("iat")]
        public long IssuedAt { get; set; }

        /// <summary>
        /// JWT過期時間
        /// </summary>
        [JsonPropertyName("exp")]
        public long Expiration { get; set; }
    }
}

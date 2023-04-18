using System.Text.Json.Serialization;

namespace JwtAuth;

public class TokenManagement
{
    [JsonInclude]
    public string Secret { get; set; }

    [JsonInclude]
    public string Issuer { get; set; }

    [JsonInclude]
    public string Audience { get; set; }

    [JsonInclude]
    public int AccessExpiration { get; set; }

    [JsonInclude]
    public int RefreshExpiration { get; set; }
}
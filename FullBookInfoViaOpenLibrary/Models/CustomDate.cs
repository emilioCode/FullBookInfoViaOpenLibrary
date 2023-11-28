using System.Text.Json.Serialization;

namespace FullBookInfoViaOpenLibrary.Models
{
    public class CustomDate
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}

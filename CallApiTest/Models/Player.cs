using Newtonsoft.Json;

namespace CallApiTest.Models
{
    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("psn")]
        public string Psn { get; set; }
    }
}
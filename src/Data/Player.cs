using Newtonsoft.Json;

namespace Nancy.Simple
{
    [JsonObject]
    class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public PlayerStatus Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("stack")]
        public int Stack { get; set; }

        [JsonProperty("bet")]
        public int Bet { get; set; }
    }
}

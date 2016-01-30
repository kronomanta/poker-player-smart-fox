using Newtonsoft.Json;

namespace Nancy.Simple
{
    [JsonObject]
    class Card
    {
        [JsonProperty("rank")]
        public Rank Rank { get; set; }

        [JsonProperty("suit")]
        public Suit Suit { get; set; }
    }
}

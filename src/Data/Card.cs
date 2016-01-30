using Newtonsoft.Json;

namespace Nancy.Simple
{
    [JsonObject]
    public class Card
    {
        [JsonConverter(typeof(RankConverter))]
        [JsonProperty("rank")]
        public Rank Rank { get; set; }

        [JsonConverter(typeof(SuitConverter))]
        [JsonProperty("suit")]
        public Suit Suit { get; set; }
    }
}

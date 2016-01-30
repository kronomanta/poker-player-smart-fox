using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nancy.Simple
{
    [JsonObject]
    public class GameState
    {
        [JsonProperty("tournament_id")]
        public string TournamentId { get; set; }

        [JsonProperty("game_id")]
        public string GameId { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("bet_index")]
        public int BetIndex { get; set; }

        [JsonProperty("small_blind")]
        public int SmallBlind { get; set; }

        [JsonProperty("current_buy_in")]
        public  int CurrentBuyIn { get; set; }

        [JsonProperty("pot")]
        public int Pot { get; set; }

        [JsonProperty("minimum_raise")]
        public int MinimumRaise { get; set; }

        [JsonProperty("dealer")]
        public int Dealer { get; set; }

        [JsonProperty("orbits")]
        public int Orbits { get; set; }

        [JsonProperty("in_action")]
        public int InAction { get; set; }

        [JsonProperty("players")]
        public IEnumerable<Player> Players { get; set; }

        [JsonProperty("community_cards")]
        public IEnumerable<Card> CommunityCards { get; set; }

        private Player _me;
        
        public Player Me
        {
            get
            {
                return _me ?? (_me = Players.ElementAt(InAction));
            }
        }

        private IEnumerable<Card> _ownCards;

        public IEnumerable<Card> OwnCards
        {
            get
            {
                return _ownCards ?? (_ownCards = CommunityCards.Concat(Me.HoleCards));
            }
        }

        private IEnumerable<IGrouping<Rank, Card>> _cardsByRank;
        
        public IEnumerable<IGrouping<Rank, Card>> CardsByRank
        {
            get
            {
                return _cardsByRank ?? (_cardsByRank = OwnCards.GroupBy(card => card.Rank));
            }
        }
        
        private bool? _hasPair;

        public bool HasPair()
        {
            return _hasPair ?? (_hasPair = CardsByRank.Any(group => group.Count() == 2)).Value;
        }

        public Player GetCurrentPlayer()
        {
            return Players.ElementAt(InAction);
        }

        /// <summary>
        /// Minimális összeg ahhoz, hogy tartsuk a tétet
        /// </summary>
        /// <returns></returns>
        public int GetValueToCall()
        {
            return CurrentBuyIn - GetCurrentPlayer().Bet;
        }
    }
}

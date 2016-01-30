using System.Collections.Generic;
using System.Linq;
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
        public int CurrentBuyIn { get; set; }

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

        public Player GetCurrentPlayer()
        {
            return _me ?? (_me = Players.ElementAt(InAction));
        }

        private IEnumerable<Card> _ownCards;

        public IEnumerable<Card> OwnCards
        {
            get
            {
                return _ownCards ?? (_ownCards = CommunityCards.Concat(GetCurrentPlayer().HoleCards));
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

        private IEnumerable<IGrouping<Suit, Card>> _cardsBySuit;

        public IEnumerable<IGrouping<Suit, Card>> CardsBySuit
        {
            get
            {
                return _cardsBySuit ?? (_cardsBySuit = OwnCards.GroupBy(card => card.Suit));
            }
        }

        private bool? _hasPair;

        public bool HasPair()
        {
            return _hasPair ?? (_hasPair = CardsByRank.Any(group => group.Count() == 2)).Value;
        }

        private bool? _hasThreeOfAKind;

        public bool HasThreeOfAKind()
        {
            return _hasThreeOfAKind ?? (_hasThreeOfAKind = CardsByRank.Any(group => group.Count() == 2)).Value;
        }

        private bool? _hasFourOfAKind;

        public bool HasFourOfAKind()
        {
            return _hasFourOfAKind ?? (_hasFourOfAKind = CardsByRank.Any(group => group.Count() == 2)).Value;
        }

        private bool? _hasFlush;

        public bool HasFlush()
        {
            return _hasFlush ?? (_hasFlush = CardsBySuit.Any(group => group.Count() == 5)).Value;
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

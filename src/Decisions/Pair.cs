using System.Collections.Generic;
using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public class Pair : IDecisionLogic
    {
        public string GetName()
        {
            return "Pair";
        }

        public int? MakeADecision(GameState gameState)
        {
            var myCards = MyCards(gameState);
            var cards = new List<Card>();
            if (HasPair(gameState.CommunityCards) != null)
            {
                cards.AddRange(myCards);
            }
            else
            {
                cards.AddRange(gameState.CommunityCards);
                cards.AddRange(myCards);
            }

            var hasAPair = HasPair(cards);
            if (hasAPair == null)
            {
                return null;
            }

            return GetBet(hasAPair.Value);
        }

        private int? GetBet(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ace:
                    return 100;
                case Rank.King:
                    return 80;
                case Rank.Queen:
                    return 60;
                default:
                    return 50;
            }
        }

        private IEnumerable<Card> MyCards(GameState gameState)
        {
            var inActionPlayer = gameState.Players.FirstOrDefault(player => player.Id == gameState.InAction);
            return inActionPlayer != null ? inActionPlayer.HoleCards : new Card[] { };
        }

        private Rank? HasPair(IEnumerable<Card> cards)
        {
            var tmpCards = new List<Card>();
            foreach (var card in cards)
            {
                if (tmpCards.Any(c => c.Rank == card.Rank))
                {
                    return card.Rank;
                }

                tmpCards.Add(card);
            }

            return null;
        }
    }
}

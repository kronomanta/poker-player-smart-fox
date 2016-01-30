using System.Collections.Generic;
using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public abstract class AbstractPair : IDecisionLogic
    {
        public abstract string GetName();

        public abstract int? MakeADecision(GameState gameState);

        protected int? GetBet(Rank rank, GameState gameState)
        {
            switch (rank)
            {
                case Rank.Ace:
                    return 500;
                case Rank.King:
                    return 400;
                case Rank.Queen:
                    return 300;
                default:
                    return 100;
            }
        }

        protected IEnumerable<Card> GetMyCards(GameState gameState)
        {
            var inActionPlayer = gameState.Players.FirstOrDefault(player => player.Id == gameState.InAction);
            return inActionPlayer != null ? inActionPlayer.HoleCards : new Card[] { };
        }

        protected Rank? HasPair(IEnumerable<Card> cards)
        {
            var tmpCards = new List<Card>();
            foreach (var card in cards)
            {
                tmpCards.Add(card);

                if (tmpCards.Count(c => c.Rank == card.Rank) == 2)
                {
                    return card.Rank;
                }
            }

            return null;
        }
    }
}

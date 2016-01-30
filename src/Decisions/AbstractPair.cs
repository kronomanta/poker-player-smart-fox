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
                    return 100;
                case Rank.King:
                    return 80;
                case Rank.Queen:
                    return 60;
                default:
                    return gameState.GetValueToCall();
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

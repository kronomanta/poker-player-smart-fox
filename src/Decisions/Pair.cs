using System.Collections.Generic;

namespace Nancy.Simple.Decisions
{
    public class Pair : AbstractPair
    {
        public override string GetName()
        {
            return "Pair";
        }

        public override int? MakeADecision(GameState gameState)
        {
            var myCards = GetMyCards(gameState);
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
    }
}

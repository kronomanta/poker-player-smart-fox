using System.Collections.Generic;
using System.Linq;

namespace Nancy.Simple.Decisions
{
    public class TwoPair : AbstractPair
    {
        public override string GetName()
        {
            return "TwoPair";
        }

        public override int? MakeADecision(GameState gameState)
        {
            var allCards = GetAllCardOnTable(gameState);
            var pairs = allCards.GroupBy(g => g.Rank).Select(group => group.Key).ToArray();
            //if (pairs.Count() == 2)
            //{
            //    pairs.Rank
            //}

            return null;
        }

        private IEnumerable<Card> GetAllCardOnTable(GameState gameState)
        {
            var cards = new List<Card>();
            cards.AddRange(gameState.CommunityCards);
            cards.AddRange(GetMyCards(gameState));
            return cards;
        }
    }
}
 
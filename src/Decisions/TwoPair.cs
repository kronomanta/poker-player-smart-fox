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
            if (gameState.GetPairs().Count() == 2)
            {
                return 10000;
            }

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
 
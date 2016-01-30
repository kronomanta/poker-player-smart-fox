using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple
{
    public class BetOnCertainty : IDecisionLogic
    {
        public int? MakeADecision(GameState gameState)
        {
            var me = gameState.Players.ElementAt(gameState.InAction);
            var cards = me.HoleCards.Concat(gameState.CommunityCards).ToArray();
            var matchingRankGroups = cards.GroupBy(card => card.Rank)
                .Select(group => group.Count())
                .ToArray();

            if (matchingRankGroups.Contains(4)
                || matchingRankGroups.Contains(3) && matchingRankGroups.Contains(2))
            {
                return 100000;
            }

            return null;
        }
    }
}

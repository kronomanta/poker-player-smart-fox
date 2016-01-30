using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    class BetOnCertainty : IDecisionLogic
    {
        public string GetName()
        {
            return "BetOnCertainty";
        }

        public int? MakeADecision(GameState gameState)
        {
            if (gameState.HasFourOfAKind()
                || gameState.HasPair() && gameState.HasThreeOfAKind())
            {
                return 100000;
            }

            return null;
        }
    }
}

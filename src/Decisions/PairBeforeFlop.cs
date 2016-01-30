using Nancy.Simple.Interface;
using System.Linq;

namespace Nancy.Simple.Decisions
{
    class PairBeforeFlop : IDecisionLogic
    {
        public string GetName()
        {
            return "PairBeforeFlop";
        }
            
        public int? MakeADecision(GameState gameState)
            {
                //csak, ha még nincsenek terített lapok
                if (gameState.CommunityCards.FirstOrDefault() == null)
                {
                    Card[] myCards = gameState.GetCurrentPlayer().HoleCards.ToArray();
                    if (myCards[0].Rank == myCards[1].Rank)
                        return 10000;
                    else return null;
                }
                else return null;
          


        }

    }
}

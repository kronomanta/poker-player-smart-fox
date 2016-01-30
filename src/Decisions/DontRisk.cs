using System;
using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public class DontRisk : IDecisionLogic
    {
        public string GetName()
        {
            return "DontRisk";
        }

        /// <summary>
        /// Ha még nincs bent pénzünk, foldol
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
		public int? MakeADecision(GameState gameState)
        {
            int? bet = null;

			Player player = gameState.Players.ElementAt(gameState.InAction);

			int currentBet = player.Bet;

			if (currentBet == 0) {
				bet = 0;
			}

            return bet;
        }
    }
}
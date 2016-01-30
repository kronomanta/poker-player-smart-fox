using System;
using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public class RandomBet : IDecisionLogic
    {
        private readonly Random rnd = new Random();

        private const int CallThreshold = 100;
        private const int StackLowerThreshold = 300;

        public string GetName()
        {
            return "RandomBet";
        }

        /// <summary>
        /// Mindig ad vissza valamit
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public int? MakeADecision(GameState gameState)
        {
            int? bet = null;

            int valueToCall = gameState.GetValueToCall();

            //ha túl kevés a pénz, akkor dobunk mindig
            if (gameState.GetCurrentPlayer().Stack < StackLowerThreshold)
                return valueToCall;

            int decision = rnd.Next(100);
            if (decision < 20)
            {
                //20% eldob
                bet = 0;
            }
            else if (decision < 70)
            {
                //50% tartom
                bet = valueToCall;
            }
            else
            {
                //25%
                int raise = gameState.MinimumRaise;

                bet = valueToCall + raise;
                if (bet >= CallThreshold)
                {
                    //ha all in lenne belőle, akkor inkább bedobjuk
                    bet = valueToCall;
                }
            }

            return bet;
        }
    }
}
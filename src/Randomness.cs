using System;
using System.Linq;
using Nancy.Simple.Interface;

namespace Nancy.Simple
{
    public class RandomBet : IDecisionLogic
    {
        private readonly Random rnd = new Random();

        private const int CallThreshold = 100;

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

            //túl nagyot nem emelünk
            if (valueToCall > CallThreshold)
                return null;

            
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
                    bet = 0;
                }
            }

            return bet;
        }
    }
}
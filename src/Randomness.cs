using System;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class RandomBet : IDecisionLogic
    {
        private readonly Random rnd = new Random();

        private const int CallThreshold = 100;

        /// <summary>
        /// Mindig ad vissza valamit
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public int? MakeADecision(JObject gameState)
        {
            int? bet = null;
            int playerInAction = (int)gameState["in_action"];

            JToken player = gameState["players"][playerInAction];
            int stack = (int)player["stack"];

            int valueToCall = (int)gameState["current_buy_in"] - (int)player["bet"];

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
                int raise = (int)gameState["minimum_raise"];

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
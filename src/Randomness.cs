using System;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class RandomBet : IDecisionLogic
    {
        private readonly Random rnd = new Random();

        /// <summary>
        /// Mindig ad vissza valamit
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public int? MakeADecision(JObject gameState)
        {
            int bet = 0;
            int playerInAction = (int)gameState["in_action"];
            int valueToCall = (int)gameState["current_buy_in"] - (int)gameState["players"][playerInAction]["bet"];

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
            }

            return bet;
        }
    }
}
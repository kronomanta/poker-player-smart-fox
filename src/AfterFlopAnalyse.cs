using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    class AfterFlopAnalyse : IDecisionLogic
    {
        public string GetName()
        {
            return "AfterFlopAnalyse";
        }

        public int? MakeADecision(GameState gameState)
        {
            //csak, ha már vannak terített lapok
            if (gameState.CommunityCards.FirstOrDefault() == null)
                return null;

            //Van-e magasabb lapom a flopnál?
            bool IsHigherThanFlop = false;
            Rank? flopMax = null;
            foreach (Card flop in gameState.CommunityCards)
            {
                if (!flopMax.HasValue || flop.Rank > flopMax)
                    flopMax = flop.Rank;
            }

            foreach (Card own in gameState.Players.ElementAt(gameState.InAction).HoleCards)
            {
                if (own.Rank > flopMax)
                    IsHigherThanFlop = true;
            }


            //sosem játszik, nem tartozik még hozzá logika
            if (IsHigherThanFlop == true)
                return 1;
            else
                return null;

        }

    }
}

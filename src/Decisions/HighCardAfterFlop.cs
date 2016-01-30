using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    class HighCardAfterFlop : IDecisionLogic
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
            Rank flopMax = Rank.Number2;
            foreach (Card flop in gameState.CommunityCards)
            {
                if (flop.Rank > flopMax)
                    flopMax = flop.Rank;
            }

            foreach (Card own in gameState.Players.ElementAt(gameState.InAction).HoleCards)
            {
                if (own.Rank > flopMax)
                {
                    IsHigherThanFlop = true;
                    break;
                }
            }


            //sosem játszik, nem tartozik még hozzá logika
            if (IsHigherThanFlop == true)
                return 200;
            else
                return null;

        }

    }
}

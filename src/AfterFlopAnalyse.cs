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
        public int? MakeADecision(JObject gameState)
        {
            //Dictionary a figurás lapok számértékéhez
            Dictionary<string, int> cardValues = new Dictionary<string, int>()
            { 
            {"2", 2}, {"3", 3}, {"4", 4},
            {"5", 5}, {"6", 6}, {"7", 7},
            {"8", 8}, {"9", 9}, {"10", 10},
            {"J", 11}, {"Q", 12}, {"K", 13},
            {"A", 14}
            };

            //Van-e magasabb lapom a flopnál?
            bool IsHigherThanFlop = false;
            int flopMax = 0;
            foreach (int flopRank in gameState["community_cards"])
            {
                if (flopRank > flopMax)
                    flopMax = flopRank;
            }
            foreach (int ownRank in gameState["players"]["hole_cards"])
            {
                if (ownRank > flopMax)
                    IsHigherThanFlop = true;
            }


            //sosem játszik, nem tartozik még hozzá logika
            if (IsHigherThanFlop == true)
                return 1;
            else
                return 0;

        }

    }
}

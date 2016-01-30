using System.Collections.Generic;
using System.Linq;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple.Decisions
{
    public class TwoPair : IDecisionLogic
    {
        public string GetName()
        {
            return "TwoPair";
        }

        public int? MakeADecision(GameState gameState)
        {
            //sosem játszik, nem tartozik még hozzá logika


            return null;
        }

        private string HasAPair(JToken cards)
        {
            //var cardType = "";
            //var tmpCards = new List<JToken>();
            //tmpCards.Any(c => c["rank"] != card["rank"]);

            //foreach (var card in cards)
            //{

            //    break;
            //}

            //return cardType;

            return "";
        }
    }
}
 
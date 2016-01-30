using System.Collections.Generic;
using System.Linq;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class TwoPair : IDecisionLogic
    {
        public int? MakeADecision(JObject jObj)
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
 
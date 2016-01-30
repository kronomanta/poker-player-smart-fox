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
            var cardType = "";
            var tmpCards = new List<JToken>();
            tmpCards.Any(c => c["rank"] != card["rank"]);

            foreach (var card in cards)
            {
                if (!))
                {
                    tmpCards.Add(card);
                    continue;
                }
                else
                {

                }


                cardType = card["rank"].ToString();
                break;
            }

            return cardType;
        }

        private int? HasHighCardOrPair(JToken cards)
        {
            var hasHighCard = false;

            foreach (var card in cards)
            {


                //if (card["rank"] > 8)
                //{
                //    hasHighCard = true;
                //    break;
                //}
            }


            return hasHighCard;
        }
    }
}
 
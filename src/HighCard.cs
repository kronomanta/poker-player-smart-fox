using System.Collections.Generic;
using System.Linq;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class HighCard : IDecisionLogic
    {
        public bool MakeADecision(JObject jObj)
        {
            var me = jObj["in_action"];

            foreach (var player in jObj["players"])
            {
                if (player["id"] == me)
                {
                    return HasHighCardOrPair(player["hole_cards"]);
                }
            }

            return false;
        }

        private bool HasAPair(JToken cards)
        {
            var haveAPair = false;
            var tmpCards = new List<JToken>();
            foreach (var card in cards)
            {
                if (!tmpCards.Any())
                {
                    tmpCards.Add(card);
                    continue;
                }

                if (tmpCards.Any(c => c["rank"] == card["rank"]))
                {
                    haveAPair = true;
                    break;
                }
            }

            return haveAPair;
        }

        private bool HasHighCardOrPair(JToken cards)
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

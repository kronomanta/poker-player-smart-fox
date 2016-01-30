using System.Collections.Generic;
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class HighCard : IDecisionLogic
    {
        private readonly Dictionary<string, int> _cardTypes = new Dictionary<string, int>
        {
            { "A", 14},
            { "K", 13},
            { "Q", 12},
            { "J", 11}
        };

        public int? MakeADecision(JObject jObj)
        {
            string highCard = "";
            int playerInAction = (int)jObj["in_action"];
            foreach (var player in jObj["players"])
            {
                if ((int)player["id"] == playerInAction)
                {
                    highCard = GetHighCard(player["hole_cards"]);
                    break;
                }
            }

            return GetBet(highCard);
        }

        private int? GetBet(string highCard)
        {
            switch (highCard)
            {
                case "A":
                    return 100;

                case "K":
                    return 60;

                case "Q":
                    return 20;

                case "J":
                    return 10;

                default:
                    return null;

            }
        }

        private string GetHighCard(JToken cards)
        {
            var lastCardValue = 0;
            var highCard = "";
            foreach (var card in cards)
            {
                var cardType = card["rank"].ToString();
                if (_cardTypes.ContainsKey(cardType))
                {
                    var currentCardValue = _cardTypes[cardType];
                    if (lastCardValue < currentCardValue)
                    {
                        lastCardValue = _cardTypes[cardType];
                        highCard = cardType;
                    }
                }
            }

            return highCard;
        }
    }
}

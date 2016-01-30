using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
        private static readonly Random rnd = new Random();

		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
		    int bet = 0;
            try
            {
                int valueToCall = (int)gameState["current_buy_in"] - (int)gameState["players"][(int)gameState["in_action"]]["bet"];

                //50% eséllyel csak tartjuk a tétet, egyébként pedig all in :D 
                bet = rnd.Next(1) == 1 ? valueToCall : 1000000;
                
            }
            catch (Exception ex)
            {
            }

            Console.WriteLine("Bet: {0}", bet);
            Console.Error.WriteLine("Bet (error): {0}", bet);

            return bet;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}


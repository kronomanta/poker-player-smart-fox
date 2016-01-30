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
		    int valueToCall = (int) gameState["current_buy_in"] - (int) gameState["players"]["in_action"]["bet"];

            //50% eséllyel csak tartjuk a tétet, egyébként pedig all in :D 
		    if (rnd.Next(1) == 1)
		        return valueToCall;
			return 1000000;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}


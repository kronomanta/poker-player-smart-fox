using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
	    private static Guid requestId = Guid.NewGuid();
        public static Guid RequestId {get { return requestId; }}
	    public static Guid GenerateRequestId()
	    {
	        return (requestId = Guid.NewGuid());
	    }

        private static readonly Random rnd = new Random();

		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
		    int bet = 0;
            try
            {
                int playerInAction = (int) gameState["in_action"];
                int valueToCall = (int)gameState["current_buy_in"] - (int)gameState["players"][playerInAction]["bet"];

                int decision = rnd.Next(10);
                if (decision < 5)
                {
                    //50% tartom
                    bet = valueToCall;
                }else if (decision < 8)
                {
                    //30% eldob
                    bet = 0;
                }else if (decision < 9)
                {
                    int raise = (int)gameState["minimum_raise"];
                    bet = valueToCall + raise;
                }
                else
                {
                    bet = 1000000;                    
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("ReqID: {0}, error: {1}",requestId, ex);
            }

            Console.WriteLine("ReqID: {0}, Bet: {1}", requestId, bet);
            

            return bet;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		    try
		    {

		    }
		    catch (Exception ex)
		    {
		        Console.Error.WriteLine(ex);
		    }
		}
	}
}


using System;
using Nancy.Simple.Interface;
using Newtonsoft.Json;
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


		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
		{
            var parsedState = JsonConvert.DeserializeObject<GameState>(gameState.ToString());

		    int bet = 0;
            try
            {
                foreach (IDecisionLogic decisionLogic in Decisions.GetDecisions())
                {
                    //végigpróbáljuk a lehetőségeket
                    int? possibleBet = decisionLogic.MakeADecision(gameState);
                    if (possibleBet.HasValue)
                {
                        bet = possibleBet.Value;
                        break;
                }
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


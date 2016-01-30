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
		    int bet = 0;
            try
            {
                var parsedState = JsonConvert.DeserializeObject<GameState>(gameState.ToString());

				foreach (IDecisionLogic decisionLogic in Decisions.DecisionFactory.GetDecisions())
                {
                    //végigpróbáljuk a lehetőségeket
                    int? possibleBet = decisionLogic.MakeADecision(parsedState);
                    if (possibleBet.HasValue)
                    {
                        bet = possibleBet.Value;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogHelper.Error("type=error action=bet_request request_id={0} error_message={1}",requestId, ex);
            }

            Logger.LogHelper.Log("type=bet action=bet_request request_id={0} bet={1}", requestId, bet);
            
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
                Logger.LogHelper.Error("type=error action=showdown error_message={1} request_id={0}", requestId, ex);
		    }
		}
	}
}


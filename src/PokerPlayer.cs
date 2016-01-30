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

		public static int BetRequest(JObject jsonState)
		{
			int bet = 0;
			var gameState = JsonConvert.DeserializeObject<GameState>(jsonState.ToString());
            try
			{
				string actualDecision = "none";
				Logger.LogHelper.Log("type=bet_begin action=bet_request request_id={0} game_id={1}", requestId, gameState.GameId);

				foreach (IDecisionLogic decisionLogic in Decisions.DecisionFactory.GetDecisions())
                {
                    //végigpróbáljuk a lehetőségeket
                    int? possibleBet = decisionLogic.MakeADecision(gameState);
                    if (possibleBet.HasValue)
                    {
                        bet = possibleBet.Value;
						actualDecision = decisionLogic.GetName();
                        break;
                    }
				}

				string cards = String.Join(",", gameState.OwnCards);
				Logger.LogHelper.Log("type=bet action=bet_request request_id={0} game_id={1} bet={2} cards={3} decision={4}",
					requestId, gameState.GameId, bet, cards, actualDecision);
            }
            catch (Exception ex)
            {
				Logger.LogHelper.Error("type=error action=bet_request request_id={0} game_id={1} error_message={2}",requestId, gameState.GameId, ex);
            }

			return bet;
		}

		public static void ShowDown(JObject jsonState)
		{
			var gameState = JsonConvert.DeserializeObject<GameState>(jsonState.ToString());
			//TODO: Use this method to showdown
		    try
		    {

		    }
		    catch (Exception ex)
		    {
				Logger.LogHelper.Error("type=error action=showdown request_id={0} game_id={1} error_message={2}", requestId, gameState.GameId, ex);
		    }
		}
	}
}


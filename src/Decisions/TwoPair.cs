using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public class TwoPair : IDecisionLogic
    {
        public string GetName()
        {
            return "TwoPair";
        }

        public int? MakeADecision(GameState gameState)
        {
            //sosem játszik, nem tartozik még hozzá logika
            return null;
        }
    }
}
 
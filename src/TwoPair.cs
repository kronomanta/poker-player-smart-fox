using Nancy.Simple.Interface;

namespace Nancy.Simple
{
    public class TwoPair : IDecisionLogic
    {
        public int? MakeADecision(GameState gameState)
        {
            //sosem játszik, nem tartozik még hozzá logika
            return null;
        }
    }
}
 
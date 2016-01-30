using Nancy.Simple.Interface;

namespace Nancy.Simple
{
    public static class Decisions
    {
        public static IDecisionLogic[] GetDecisions()
        {
            var decisions = new IDecisionLogic[]
            {
                new BetOnCertainty(),
                new TwoPair(), 
            };

            return decisions;
        }
    }
}

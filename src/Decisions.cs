using Nancy.Simple.Interface;

namespace Nancy.Simple
{
    public class Decisions
    {
        public IDecisionLogic[] GetDecisions()
        {
            var decisions = new IDecisionLogic[]
            {
                new TwoPair(), 
            };

            return decisions;
        }
    }
}

using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class TwoPair : IDecisionLogic
    {
        public bool MakeADecision(JObject jObj)
        {
            return false;
        }
    }
}
 
using Nancy.Simple.Interface;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class TwoPair : IDecisionLogic
    {
        public int? MakeADecision(JObject jObj)
        {
            //sosem játszik, nem tartozik még hozzá logika
            return null;
        }
    }
}
 
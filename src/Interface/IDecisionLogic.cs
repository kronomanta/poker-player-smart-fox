using Newtonsoft.Json.Linq;

namespace Nancy.Simple.Interface
{
    public interface IDecisionLogic
    {
        bool MakeADecision(JObject jObj);
    }
}

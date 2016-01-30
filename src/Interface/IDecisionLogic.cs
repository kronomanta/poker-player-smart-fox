using Newtonsoft.Json.Linq;

namespace Nancy.Simple.Interface
{
    public interface IDecisionLogic
    {
        /// <summary>
        /// Eldönti, hogy akar-e megtenni tétet, és ha igen, akkor milyet
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        int? MakeADecision(JObject gameState);
    }
}

namespace Nancy.Simple.Decisions
{
    public class TwoPair : AbstractPair
    {
        public override string GetName()
        {
            return "TwoPair";
        }

        public override int? MakeADecision(GameState gameState)
        {
            var myCards = GetMyCards(gameState);


            return null;
        }
    }
}
 
﻿using Nancy.Simple.Interface;

namespace Nancy.Simple.Decisions
{
    public static class DecisionFactory
    {
        public static IDecisionLogic[] GetDecisions()
        {
			var decisions = new IDecisionLogic[] {
				new BetOnCertainty (),
				new DontRisk (), 
				new TwoPair (), 
				new RandomBet ()
			};

            return decisions;
        }
    }
}

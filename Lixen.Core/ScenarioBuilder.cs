using System;
using System.Collections.Generic;

namespace Lixen.Core
{
    public class ScenarioBuilder
    {
        private Type _scenarioType;

        private Dictionary<string, Type> _scenarioMap = new Dictionary<string, Type>
        {
            {"Liquidation", typeof(LiquidationScenario)},
            {"StressTest", typeof(StressTestScenario)}
        };
        
        private ScenarioBuilder(){}

        private void SetType(Type type)
        {
            _scenarioType = type;
            //return this;
        }
        
//        public ScenarioBuilder OfType<T>()
//        {
//            return OfType(typeof(T));
//        }
        
        public static ScenarioBuilder Create<T>() where T : IScenario
        {
            var builder = new ScenarioBuilder();
            builder.SetType(typeof(T));
            return builder;
        }

        public IScenario Build()
        {
            
            return new LiquidationScenario();
        }
        
    }
}
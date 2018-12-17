using System;
using System.Collections.Generic;

namespace Lixen.Core
{
    public class ScenarioBuilder
    {
        private Type _scenarioType;
        private int _scenarioId;
        private AbstractSpecification<IPosition> _specification;

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
        
        public static ScenarioBuilder Create<T>() where T : IScenario<IPosition>
        {
            var builder = new ScenarioBuilder();
            builder.SetType(typeof(T));
            return builder;
        }

        public ScenarioBuilder WithId(int scenarioId)
        {
            _scenarioId = scenarioId;
            return this;
        }

        public ScenarioBuilder WithSpecification(AbstractSpecification<IPosition> specification)
        {
            _specification = _specification == null ? specification : _specification.And(specification);
            return this;
        }

        public IScenario<IPosition> Build()
        {
            return new LiquidationScenario(_scenarioId, string.Empty, 10.0, _specification.ToExpression());
        }
        
    }
}
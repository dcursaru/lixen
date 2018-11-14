using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class LiquidationScenario : IScenario<LiquidationScenario>
    {
        public LiquidationScenario(int id, string name, double liquidationFactor, Expression<Func<LiquidationScenario, bool>> liquidationFilter)
        {
            Id = id;
            Name = name;
            LiquidationFactor = liquidationFactor;
            LiquidationFilter = liquidationFilter;
        }

        public int Id { get; }
        public string Name { get; }
        
        public double LiquidationFactor { get; }
        public Expression<Func<LiquidationScenario, bool>> LiquidationFilter { get; }
    }
}
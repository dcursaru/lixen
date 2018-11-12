using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class LiquidationScenario : IScenario<LiquidationScenario>
    {
        public LiquidationScenario(int id, string description, double liquidationFactor, Expression<Func<LiquidationScenario, bool>> liquidationFilter)
        {
            Id = id;
            Description = description;
            LiquidationFactor = liquidationFactor;
            LiquidationFilter = liquidationFilter;
        }

        public int Id { get; }
        public string Description { get; }
        
        public double LiquidationFactor { get; }
        public Expression<Func<LiquidationScenario, bool>> LiquidationFilter { get; }
    }
}
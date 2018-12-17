using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class LiquidationScenario : IScenario<IPosition>
    {
        public LiquidationScenario(int id, string name, double liquidationFactor, Expression<Func<IPosition, bool>> liquidationFilter)
        {
            Id = id;
            Name = name;
            LiquidationFactor = liquidationFactor;
            LiquidationFilter = liquidationFilter;
        }

        public int Id { get; }
        public string Name { get; }
        
        public double LiquidationFactor { get; }
        public Expression<Func<IPosition, bool>> LiquidationFilter { get; }
    }
}
using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public interface IScenario<T>
    {
        int Id { get; }
        string Description { get; }
        double LiquidationFactor { get; }
        Expression<Func<T, bool>> LiquidationFilter { get; }
    }

    public interface ILiquidable
    {
        double LiquidationFactor { get; }
    }

    public interface IPosition
    {
        string Id { get; }
        string Broker { get; }
    }
}
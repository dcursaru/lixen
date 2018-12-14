using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public interface IScenario<T> where T: IPosition
    {
        int Id { get; }
        string Name { get; }
        double LiquidationFactor { get; }
        Expression<Func<T, bool>> LiquidationFilter { get; }
    }

    public interface ILiquidatable
    {
        double LiquidationFactor { get; }
    }

    public interface IPosition
    {
        string Id { get; }
        string Broker { get; }
    }

    public class Position : IPosition
    {
        public Position(string broker, string id)
        {
            Broker = broker;
            Id = id;
        }

        public string Id { get; }
        public string Broker { get; }
    }
}
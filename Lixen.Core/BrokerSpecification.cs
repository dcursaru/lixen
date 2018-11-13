using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class BrokerSpecification : AbstractSpecification<IPosition>
    {
        private readonly string[] _brokers;
        
        public BrokerSpecification(params string[] brokers)
        {
            _brokers = brokers;
        }
        
        public override Expression<Func<IPosition, bool>> ToExpression()
        {
            return p => _brokers.Contains(p.Broker);
        }
    }
}
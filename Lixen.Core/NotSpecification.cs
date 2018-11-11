using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class NotSpecification<T> : AbstractSpecification<T> 
    {
        private readonly AbstractSpecification<T> _spec;

        public NotSpecification(AbstractSpecification<T> spec)
        {
            _spec = spec;
        }

        public override Expression<Func<T, bool>> ToExpression() {
            var spec = _spec.ToExpression();
            
            var parameterExpression = Expression.Parameter(typeof(T));
            var expressionBody = Expression.Not(spec.Body);
            expressionBody = (UnaryExpression)new ParameterReplacer(parameterExpression).Visit(expressionBody);
            
            var result = Expression.Lambda<Func<T, bool>>(expressionBody, parameterExpression);

            return result;
        }
    }
}
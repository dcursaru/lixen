using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class NotSpecification<T> : AbstractSpecification<T> 
    {
        private readonly AbstractSpecification<T> _specification;

        public NotSpecification(AbstractSpecification<T> specification)
        {
            _specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression() {
            var spec = _specification.ToExpression();
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.Not(spec.Body);
            body = (UnaryExpression)new ParameterReplacer(parameter).Visit(body);

            return Expression.Lambda<Func<T, bool>>(
                body ?? throw new InvalidOperationException("Null expression body"), parameter);
        }
    }
}
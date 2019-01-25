using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class OrSpecification<T> : AbstractSpecification<T> 
    {
        private readonly AbstractSpecification<T> _leftSpecification;
        private readonly AbstractSpecification<T> _rightSpecification;


        public OrSpecification(AbstractSpecification<T> left, AbstractSpecification<T> right) {
            _rightSpecification = right;
            _leftSpecification = left;
        }


        public override Expression<Func<T, bool>> ToExpression() {
            var leftExpression = _leftSpecification.ToExpression();
            var rightExpression = _rightSpecification.ToExpression();
            
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            body = (BinaryExpression)new ParameterReplacer(parameter).Visit(body);

            return Expression.Lambda<Func<T, bool>>(
                body ?? throw new InvalidOperationException("Expression body cannot be null"), parameter);
        }
    }

    
}
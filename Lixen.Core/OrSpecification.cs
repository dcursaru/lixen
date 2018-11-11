using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class OrSpecification<T> : AbstractSpecification<T> 
    {
        private readonly AbstractSpecification<T> _left;
        private readonly AbstractSpecification<T> _right;


        public OrSpecification(AbstractSpecification<T> left, AbstractSpecification<T> right) {
            _right = right;
            _left = left;
        }


        public override Expression<Func<T, bool>> ToExpression() {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            
            var parameterExpression = Expression.Parameter(typeof(T));
            var expressionBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            expressionBody = (BinaryExpression)new ParameterReplacer(parameterExpression).Visit(expressionBody);
            
            var result = Expression.Lambda<Func<T, bool>>(expressionBody, parameterExpression);

            return result;
        }
    }
}
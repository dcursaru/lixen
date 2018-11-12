using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class AndSpecification<T> : AbstractSpecification<T> {
        private readonly AbstractSpecification<T> _left;
        private readonly AbstractSpecification<T> _right;

        public AndSpecification(AbstractSpecification<T> left, AbstractSpecification<T> right) {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> ToExpression() {
            Expression<Func<T, bool>> leftExpression = _left.ToExpression();
            Expression<Func<T, bool>> rightExpression = _right.ToExpression();

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }


    }
}
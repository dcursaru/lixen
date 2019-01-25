using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public class EmptySpecification<T> : AbstractSpecification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.Empty();
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
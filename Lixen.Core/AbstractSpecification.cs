using System;
using System.Linq.Expressions;

namespace Lixen.Core
{
    public abstract class AbstractSpecification<T> 
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity) 
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public AbstractSpecification<T> And(AbstractSpecification<T> specification) 
        {
            return new AndSpecification<T>(this, specification);
        }

        public AbstractSpecification<T> Or(AbstractSpecification<T> specification) 
        {
            return new OrSpecification<T>(this, specification);
        }

        public AbstractSpecification<T> Not(AbstractSpecification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }
    }
}
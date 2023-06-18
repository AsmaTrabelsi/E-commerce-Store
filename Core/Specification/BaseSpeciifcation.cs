using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Specification
{
    public class BaseSpeciifcation<T> : ISpecification<T>
    {
        public BaseSpeciifcation()
        {

        }
        public BaseSpeciifcation(Expression<Func<T, bool>> Criteria)
        {
            Criteria = Criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }

}

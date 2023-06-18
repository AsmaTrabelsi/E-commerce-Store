using System.Linq.Expressions;


namespace Infrastructure.Data.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
    }
}

using System.Linq.Expressions;

namespace LernAndDelete.SpecificationPattern
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> ToExpression();
    }

}

using LernAndDelete.Areas.Admin.Models;
using LernAndDelete.Models;
using System.Linq.Expressions;

namespace LernAndDelete.SpecificationPattern
{
    public class BooksByAuthorSpecification : ISpecification<Book>
    {
        private readonly string _authorName;

        public BooksByAuthorSpecification(string authorName)
        {
            _authorName = authorName;
        }

        public Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.Author == _authorName;
        }

        public BooksByAuthorSpecification()
        {
        }

        public BooksByAuthorSpecification(string authorSearch)
            : base(b => string.IsNullOrEmpty(authorSearch) || b.Author.Contains(authorSearch))
        {
        }
    }

}

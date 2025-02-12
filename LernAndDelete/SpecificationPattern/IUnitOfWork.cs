using LernAndDelete.Areas.Admin.Models;
using LernAndDelete.Models;

namespace LernAndDelete.SpecificationPattern
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        Task<int> CompleteAsync();
    }
}

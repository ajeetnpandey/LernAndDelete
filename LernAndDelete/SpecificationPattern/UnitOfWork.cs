using LernAndDelete.Models;
using LernAndDelete.Data;

namespace LernAndDelete.SpecificationPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Book> Books => new Repository<Book>(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}

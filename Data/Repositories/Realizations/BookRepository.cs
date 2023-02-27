using Data.Data;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Realizations
{
    public class BookRepository : BaseRepository <Book>, IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

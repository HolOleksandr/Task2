using Data.Data;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq.Dynamic.Core;


namespace Data.Repositories.Realizations
{
    public class BookRepository : BaseRepository <Book>, IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllWithDetailsAsync()
        {
            return await _dbContext.Books
                .Include(b=> b.Ratings)
                .Include(b => b.Reviews)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithDetailsInOrderAsync(string order)
        {
            var sortOrder = "ASC";
            var result = await _dbContext.Books
                .Include(b => b.Ratings)
                .Include(b => b.Reviews).ToListAsync();

            if (!string.IsNullOrEmpty(order) && IsValidProperty(order))
            {
                IEnumerable<Book> orderedRes = result.AsQueryable().OrderBy(
                        string.Format("{0} {1}", order, sortOrder));
                result = await Task.FromResult(orderedRes.ToList());
            }
            return result;
        }

        public async Task<IEnumerable<Book>> GetTopBooks(int booksCount, int minReviewsCount, string? genre = null)
        {
            var books = await _dbContext.Books
                .Include(b => b.Ratings)
                .Include(b => b.Reviews)
                .OrderByDescending(y => y.Ratings.Select(r => r.Score).Average())
                .Where(b => b.Reviews.Count > minReviewsCount)
                .Take(booksCount)
                .ToListAsync();

            if (genre != null)
                books = books.Where(b => b.Genre == genre).ToList(); 

            return books;
        }

        public async Task<Book?> GetBookWithDetailsByIdAsync(int id)
        {
            var book = await _dbContext.Books
               .Include(b => b.Ratings)
               .Include(b => b.Reviews)
               .FirstOrDefaultAsync(b => b.Id == id);

            return book;
        }





        public bool IsExistsGenre(string genre)
        {
            bool result = _dbContext.Books.Select(b=> b.Genre).Contains(genre);
            return result;
        }

        public bool IsExistsBook(int id)
        {
            bool result = _dbContext.Books.Select(b => b.Id).Contains(id);
            return result;
        }



        private static bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var prop = typeof(Book).GetProperty(
            propertyName,
            BindingFlags.IgnoreCase |
            BindingFlags.Public |
            BindingFlags.Instance);
            if (prop == null && throwExceptionIfNotFound)
                throw new NotSupportedException(
                string.Format(
                $"ERROR: Property '{propertyName}' does not exist.")
                );
            return prop != null;
        }





    }
}

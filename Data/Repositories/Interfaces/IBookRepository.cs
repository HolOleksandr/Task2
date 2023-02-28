using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IBookRepository : IBaseRepository <Book>
    {
        Task<IEnumerable<Book>> GetAllWithDetailsAsync();
        Task<IEnumerable<Book>> GetAllWithDetailsInOrderAsync(string order);
        Task<IEnumerable<Book>> GetTopBooks(int booksCount, int minReviewsCount, string? genre);

        Task<Book?> GetBookWithDetailsByIdAsync(int id);

        bool IsExistsGenre(string genre);
        bool IsExistsBook(int id);
    }
}

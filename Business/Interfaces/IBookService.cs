using Business.DTO;
using Business.RequestModels;
using System.Net.Sockets;

namespace Business.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookListDto>> GetAllBooksAsync();
        Task<IEnumerable<BookListDto>> GetAllBooksInOrderAsync(string order);
        Task<IEnumerable<BookListDto>> GetTopBooksInOrderByRatingAsync(string? genre);
        Task DeleteByIdWithSecret(int id, string? secret);
        Task<int> AddOrUpdateBook(BookRequestModel bookRequestModel);
        Task<BookDetailsDto> GetBookDetailsById(int id);

        
    }
}

using AutoMapper;
using Business.DTO;
using Business.Exceptions;
using Business.Interfaces;
using Business.RequestModels;
using Data.Entities;
using Data.UoW.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public BookService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<BookListDto>> GetAllBooksAsync()
        {
            var books = await _unitOfWork.BookRepository.GetAllWithDetailsAsync();
            var booksModels = _mapper.Map<IEnumerable<BookListDto>>(books);
            return booksModels;
        }

        public async Task<IEnumerable<BookListDto>> GetAllBooksInOrderAsync(string order)
        {
            string[] orders = { "title", "author" };
            if (!orders.Contains(order))
                throw new LibraryException("Wrong sorting value");

            var books = await _unitOfWork.BookRepository.GetAllWithDetailsInOrderAsync(order);
            if (books == null)
                throw new LibraryException("Books was not found");

            var booksModels = _mapper.Map<IEnumerable<BookListDto>>(books);
            return booksModels;

        }

        public async Task<IEnumerable<BookListDto>> GetTopBooksInOrderByRatingAsync(string? genre)
        {
            if (genre != null)
            {
                if (!_unitOfWork.BookRepository.IsExistsGenre(genre))
                    throw new LibraryException("Genre does not exist");
            }
            int booksCount = 10;
            int minReviewsCount = 1;

            var books = await _unitOfWork.BookRepository.GetTopBooks(booksCount, minReviewsCount, genre);
            var booksModels = _mapper.Map<IEnumerable<BookListDto>>(books);
            return booksModels;
        }

        public async Task<BookDetailsDto> GetBookDetailsById(int id)
        {
            var book = await _unitOfWork.BookRepository.GetBookWithDetailsByIdAsync(id);

            if (book == null)
                throw new LibraryException("Book was not found");

            var bookModel = _mapper.Map<BookDetailsDto>(book);
            return bookModel;
        }

        public async Task DeleteByIdWithSecret(int id, string? secret)
        {
            var appSecret = _configuration["Secret"];
            if (!appSecret.Equals(secret))
                throw new LibraryException("Wrong secret");
            var book = await _unitOfWork.BookRepository.GetByIdAsync(id);
            if (book == null)
                throw new LibraryException("Book does not exist");
            await _unitOfWork.BookRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<int> AddOrUpdateBook(BookRequestModel bookRequestModel)
        {

            var isExistBook = _unitOfWork.BookRepository.IsExistsBook(bookRequestModel.Id);
            var book = _mapper.Map<Book>(bookRequestModel);
            if (isExistBook)
            {
                _unitOfWork.BookRepository.Update(book);
            }
            else
            {
                await _unitOfWork.BookRepository.AddAsync(book);
            }

            await _unitOfWork.SaveAsync();
            return book.Id;

        }



    }
}

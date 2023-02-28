using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.RequestModels;
using Data.Entities;
using Data.UoW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RatingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddRating(int bookId, RatingRequestModel ratingRequestModel)
        {
            var isExistsBook = _unitOfWork.BookRepository.IsExistsBook(bookId);
            if (!isExistsBook)
                throw new LibraryException("Book not found");

            var rating = _mapper.Map<Rating>(ratingRequestModel);
            rating.BookId = bookId;

            await _unitOfWork.RatingRepository.AddAsync(rating);
            await _unitOfWork.SaveAsync();
        }
    }
}

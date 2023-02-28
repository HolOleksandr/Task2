using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.RequestModels;
using Data.Entities;
using Data.UoW.Interface;
using Data.UoW.Realization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddReview(int bookId, ReviewRequestModel reviewRequestModel)
        {
            var isExistsBook = _unitOfWork.BookRepository.IsExistsBook(bookId);
            if (!isExistsBook)
                throw new LibraryException("Book not found");

            var review = _mapper.Map<Review>(reviewRequestModel);
            review.BookId = bookId;

            await _unitOfWork.ReviewRepository.AddAsync(review);
            await _unitOfWork.SaveAsync();
            return review.Id;
        }
    }
}

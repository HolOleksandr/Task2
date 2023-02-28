using Business.Interfaces;
using Business.RequestModels;
using Business.Validators;
using Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IReviewService _reviewService;
        private readonly IRatingService _ratingService;
        private readonly IValidator<BookRequestModel> _bookRequestValidator;
        private readonly IValidator<ReviewRequestModel> _reviewRequestValidator;
        private readonly IValidator<RatingRequestModel> _ratingRequestValidator;


        public BooksController(IBookService bookService,
            IReviewService reviewService,
            IRatingService ratingService,
            IValidator<BookRequestModel> bookRequestValidator,
            IValidator<ReviewRequestModel> reviewRequestValidator,
            IValidator<RatingRequestModel> ratingRequestValidator)
        {
            _bookService = bookService;
            _reviewService = reviewService;
            _ratingService = ratingService;
            _bookRequestValidator = bookRequestValidator;
            _reviewRequestValidator = reviewRequestValidator;
            _ratingRequestValidator = ratingRequestValidator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllBooksInOrder([FromQuery] string order)
        {
            var books = await _bookService.GetAllBooksInOrderAsync(order);
            return Ok(books);
        }

        [HttpGet("recomended")]
        public async Task<IActionResult> GetTopBooksInOrderByRating([FromQuery] string? genre)
        {
            var books = await _bookService.GetTopBooksInOrderByRatingAsync(genre);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookDetailsById(int id)
        {
            var book = await _bookService.GetBookDetailsById(id);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookByIdWithSecret(int id, [FromQuery] string? secret)
        {
            await _bookService.DeleteByIdWithSecret(id, secret);
            return Ok();
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveANewOrUpdateBook([FromBody] BookRequestModel bookRequestModel)
        {
            var validation = await _bookRequestValidator.ValidateAsync(bookRequestModel);
            if (!validation.IsValid)
                return StatusCode(400, validation.Errors.Select(e => e.ErrorMessage));

            var id = await _bookService.AddOrUpdateBook(bookRequestModel);
            return Ok(new { id = id });
        }

        [HttpPost("{id}/review")]
        public async Task<IActionResult> AddReviewForBook(int id, [FromBody] ReviewRequestModel reviewRequestModel)
        {
            var validation = await _reviewRequestValidator.ValidateAsync(reviewRequestModel);
            if (!validation.IsValid)
                return StatusCode(400, validation.Errors.Select(e => e.ErrorMessage));

            int reviewId = await _reviewService.AddReview(id, reviewRequestModel);
            return Ok(new { id = reviewId });
        }

        [HttpPost("{id}/rate")]
        public async Task<IActionResult> AddRatingForBook(int id, [FromBody] RatingRequestModel ratingRequestModel)
        {
            var validation = await _ratingRequestValidator.ValidateAsync(ratingRequestModel);
            if (!validation.IsValid)
                return StatusCode(400, validation.Errors.Select(e => e.ErrorMessage));

            await _ratingService.AddRating(id, ratingRequestModel);
            return Ok();
        }

    }
}

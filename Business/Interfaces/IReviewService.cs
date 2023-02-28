using Business.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IReviewService
    {
        Task<int> AddReview(int bookId, ReviewRequestModel reviewRequestModel);
    }
}

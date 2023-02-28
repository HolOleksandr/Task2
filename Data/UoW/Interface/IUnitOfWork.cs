using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UoW.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IRatingRepository RatingRepository { get; }
        Task SaveAsync();
    }
}

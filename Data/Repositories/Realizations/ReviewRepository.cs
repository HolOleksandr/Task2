using Data.Data;
using Data.Entities;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Realizations
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        private readonly LibraryDbContext _dbContext;

        public ReviewRepository(LibraryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");
            builder.HasData
                (
                    new Rating { Id = 1, BookId = 1, Score = 5.6M},
                    new Rating { Id = 2, BookId = 1, Score = 5.6M},
                    new Rating { Id = 3, BookId = 2, Score = 10M},
                    new Rating { Id = 4, BookId = 2, Score = 7.3M},
                    new Rating { Id = 5, BookId = 3, Score = 6.6M},
                    new Rating { Id = 6, BookId = 3, Score = 5.6M},
                    new Rating { Id = 7, BookId = 4, Score = 3.2M},
                    new Rating { Id = 8, BookId = 5, Score = 2M},
                    new Rating { Id = 9, BookId = 6, Score = 3.2M},
                    new Rating { Id = 10, BookId = 6, Score = 9.9M},
                    new Rating { Id = 11, BookId = 7, Score = 8.6M},
                    new Rating { Id = 12, BookId = 7, Score = 7.6M},
                    new Rating { Id = 13, BookId = 8, Score = 5.6M},
                    new Rating { Id = 14, BookId = 8, Score = 5.5M},
                    new Rating { Id = 15, BookId = 9, Score = 6.6M},
                    new Rating { Id = 16, BookId = 9, Score = 8.9M},
                    new Rating { Id = 17, BookId = 10, Score = 10M},
                    new Rating { Id = 18, BookId = 10, Score = 2.4M}
                );
        }
    }
}

using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasData
                (
                    new Review { Id= 1, BookId = 1, Message = "message 1", Reviewer = "Reviewer 1"},
                    new Review { Id = 2, BookId = 2, Message = "message 2", Reviewer = "Reviewer 2" },
                    new Review { Id = 3, BookId = 2, Message = "message 3", Reviewer = "Reviewer 1" },
                    new Review { Id = 4, BookId = 1, Message = "message 4", Reviewer = "Reviewer 2" },
                    new Review { Id = 5, BookId = 3, Message = "message 5", Reviewer = "Reviewer 3" },
                    new Review { Id = 6, BookId = 3, Message = "message 6", Reviewer = "Reviewer 1" },
                    new Review { Id = 7, BookId = 4, Message = "message 7", Reviewer = "Reviewer 6" }
                );
        }
    }
}

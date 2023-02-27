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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasData
                (
                    new Book { Id = 1, Author = "Author 1", Content = "Text 1", Genre = "horror", Title = "Title 1"},
                    new Book { Id = 2, Author = "Author 2", Content = "Text 2", Genre = "comedy", Title = "Title 2"},
                    new Book { Id = 3, Author = "Author 1", Content = "Text 3", Genre = "horror", Title = "Title 3"},
                    new Book { Id = 4, Author = "Author 3", Content = "Text 4", Genre = "fantasy", Title = "Title 4"},
                    new Book { Id = 5, Author = "Author 4", Content = "Text 5", Genre = "horror", Title = "Title 5"},
                    new Book { Id = 6, Author = "Author 2", Content = "Text 6", Genre = "historical", Title = "Title 6"},
                    new Book { Id = 7, Author = "Author 5", Content = "Text 7", Genre = "comedy", Title = "Title 7"},
                    new Book { Id = 8, Author = "Author 5", Content = "Text 8", Genre = "historical", Title = "Title 8"},
                    new Book { Id = 9, Author = "Author 2", Content = "Text 9", Genre = "comedy", Title = "Title 9"},
                    new Book { Id = 10, Author = "Author 1", Content = "Text 10", Genre = "Travel", Title = "Title 10"}
                );
        }
    }
}

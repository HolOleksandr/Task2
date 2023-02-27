using System;

namespace Data.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Cover { get; set; }
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Genre { get; set; }

        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
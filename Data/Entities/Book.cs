using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Book : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Cover { get; set; }
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Genre { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; } = null!;
    }
}
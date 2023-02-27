using System;

namespace Data.Entities
{
    public class Review : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public string Reviewer { get; set; } = null!;
    }
}




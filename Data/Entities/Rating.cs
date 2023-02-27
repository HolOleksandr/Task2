using System;

namespace Data.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }
        public decimal Score { get; set; }
    }
}
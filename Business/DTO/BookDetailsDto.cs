using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? Cover { get; set; }
        public decimal Rating { get; set; }
        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}

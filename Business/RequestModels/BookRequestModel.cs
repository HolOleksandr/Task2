using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RequestModels
{
    public class BookRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Cover { get; set; }
        public string Content { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Author { get; set; } = null!;
    }
}

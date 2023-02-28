using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
    }
}

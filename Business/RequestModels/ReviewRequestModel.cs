using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RequestModels
{
    public class ReviewRequestModel
    {
        public string Message { get; set; } = null!;
        public string Reviewer { get; set; } = null!;
    }
}

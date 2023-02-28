using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}

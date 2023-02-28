using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    [Serializable]
    public class LibraryException : Exception
    {
        public LibraryException() { }

        public LibraryException(string message) : base(message) { }

        public LibraryException(string message, Exception innerException) : base(message, innerException) { }

        protected LibraryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

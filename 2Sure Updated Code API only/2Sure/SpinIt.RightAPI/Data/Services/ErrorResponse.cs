using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinIt.Data.Services
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
    }
}

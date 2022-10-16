using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinIt.Data.Services
{
    public class APIResponse
    {
        public int ResponseCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ResponseData { get; set; }
        public ErrorResponse ErrorData { get; set; }

        public APIResponse(bool isSuccess, int code)
        {
            this.IsSuccess = isSuccess;
            this.ResponseCode = code;
        }
    }
}

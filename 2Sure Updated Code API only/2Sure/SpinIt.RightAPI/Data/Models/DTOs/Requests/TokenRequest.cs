using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Spinit.Data.Models.DTOs.Requests
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RequestToken { get; set; }
    }
}

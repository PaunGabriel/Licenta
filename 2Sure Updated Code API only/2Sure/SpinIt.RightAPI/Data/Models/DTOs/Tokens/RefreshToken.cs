using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Spinit.Data.Models.DTOs.Tokens
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Token { get; set; }
        public string JwtID { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
    }
}

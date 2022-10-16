using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Spinit.Data.Models
{

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() {            
            Orders = new HashSet<PurchaseOrder>();
        }

        //public int Id { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        //public string UserName { get; set; }
        //public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Mobile { get; set; }
        //public string Email { get; set; }

        //public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<PurchaseOrder> Orders { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
    
}
